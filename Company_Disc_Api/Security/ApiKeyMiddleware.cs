namespace Company_Disc_Api.Security
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _apiKey;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _apiKey = config.GetValue<string>("ApiSettings:ApiKey") ?? "";
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Query.TryGetValue("key", out var extractedKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key is missing.");
                return;
            }

            if (!_apiKey.Equals(extractedKey))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Invalid API Key.");
                return;
            }

            await _next(context);
        }
    }

}

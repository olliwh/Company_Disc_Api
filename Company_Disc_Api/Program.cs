using Company_Disc_Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
string allowAll = "AllowAll";
string withOrigin = "WithOrigin";
string onlyGet = "OnlyGet";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAll,
                              policy =>
                              {
                                  policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                              });
    options.AddPolicy(name: withOrigin,
                              policy =>
                              {
                                  //policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                                  policy.WithOrigins("http://zealand.dk").WithMethods("Post", "Put").SetPreflightMaxAge(TimeSpan.FromSeconds(1440)).AllowAnyHeader();

                              });
    options.AddPolicy(name: onlyGet,
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .WithMethods("GET")
                                  .AllowAnyHeader();
                              });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDiscTypesRepository, DiscTypesRepository>();
builder.Services.AddSingleton<IDepartmentsRepository, DepartmentsRepository>();
builder.Services.AddSingleton<IEmployeesRepository, EmployeesRepository>();

var app = builder.Build();
app.UseCors(allowAll);


app.Use(async (context, next) =>
{
    if (!context.Request.Headers.TryGetValue("X-API-Key", out var apiKey) ||
        apiKey != builder.Configuration["ApiKey"])
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Unauthorized - Invalid API Key");
        return;
    }
    await next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

app.Run();


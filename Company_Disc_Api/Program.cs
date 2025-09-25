using Company_Disc_Api.Repositories;
using Company_Disc_Api.Security;

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
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDiscTypesRepository, DiscTypesRepository>();
builder.Services.AddSingleton<IDepartmentsRepository, DepartmentsRepository>();
builder.Services.AddSingleton<IEmployeesRepository, EmployeesRepository>();

var app = builder.Build();
app.UseCors(allowAll);




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthorization();
app.MapControllers();



app.Run();


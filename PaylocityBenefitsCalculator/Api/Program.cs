using Api.Database;
using Api.Repositories.Implementations;
using Api.Repositories.Interfaces;
using Api.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Employee Benefit Cost Calculation Api",
        Description = "Api to support employee benefit cost calculations"
    });
});

var allowLocalhost = "allow localhost";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowLocalhost,
        policy  =>
        {
            policy.WithOrigins("http://localhost:3000", "http://localhost");
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});

builder.Services.AddSingleton<DependentEmployeeJoinTable>();
builder.Services.AddSingleton<DependentsTable>();
builder.Services.AddSingleton<EmployeesTable>();

builder.Services.AddScoped<IDependentsRepository, DependentsRepository>();
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();

builder.Services.AddScoped<DependentsService>();
builder.Services.AddScoped<EmployeesService>();
builder.Services.AddScoped<PayrollService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowLocalhost);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

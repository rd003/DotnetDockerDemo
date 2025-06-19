using DotnetDockerDemo.Api.Models;
using Microsoft.EntityFrameworkCore;
using DotnetDockerDemo.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddDbContext<PersonContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddTransient<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();


var app = builder.Build();
SeedDatabase();
app.MapControllers();

app.Run();

async void SeedDatabase()
{
    using var scope = app.Services.CreateScope();
    var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
    if (dbInitializer == null) return;
    await dbInitializer.InitializeAsync();
}
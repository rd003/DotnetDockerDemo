using DotnetDockerDemo.Api.Models;
using Microsoft.EntityFrameworkCore;
using DotnetDockerDemo.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<PersonContext>(o => o.UseSqlServer(connectionString));
builder.Services.AddTransient<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();


var app = builder.Build();

SeedDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


async void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
        if (dbInitializer == null) return;
        await dbInitializer.InitializeAsync();
    }
}
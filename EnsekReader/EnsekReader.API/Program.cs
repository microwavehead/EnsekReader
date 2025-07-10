using EnsekReader.API.Models.Database;
using EnsekReader.API.Services;
using EnsekReader.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EnsekDbContext>(options => {
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 0)));
});

builder.Services.AddScoped<IDatabaseService, DatabaseService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EnsekDbContext>();

    try
    {
        if (db.Database.CanConnect())
        {
            db.Database.Migrate();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

app.Run();

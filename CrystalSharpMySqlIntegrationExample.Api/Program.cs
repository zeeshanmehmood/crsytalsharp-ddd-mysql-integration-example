using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CrystalSharp;
using CrystalSharp.MySql.Extensions;
using CrystalSharpMySqlIntegrationExample.Application.CommandHandlers;
using CrystalSharpMySqlIntegrationExample.Application.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbConnectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
MySqlSettings dbSettings = new(dbConnectionString);

CrystalSharpAdapter.New(builder.Services)
    .AddCqrs(typeof(CreateCurrencyCommandHandler))
    .AddMySql<AppDbContext>(dbSettings)
    .CreateResolver();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

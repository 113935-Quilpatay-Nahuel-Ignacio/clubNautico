using ApiClubNautico.Business.SocioBusiness.Commands;
using ApiClubNautico.Business.SocioBusiness.Queries;
using ApiClubNautico.Data;
using ApiClubNautico.Validations.Socios;
using ApiClubNautico.Validations.Socios.Interface;
using FluentValidation.AspNetCore;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyección de dependencias
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddScoped<IExisteSocio, ExisteSocio>();

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

app.Run();

//NuGets:
//Microsoft.EntityFrameworkCore
//Microsoft.EntityFrameworkCore.Tools
//Npgsql.EntityFrameworkCore.PosgreSQL
//MediatR
//FluentValidation.AspNetCore

//appsettings.json:
/*  "ConnectionStrings": {
    "connectionString": "Server=localhost;Port=5432;Database=;User Id=;Password=;"
  }*/

//Consola del administrador de paquetes:    
//Previamente crear carpetas: Models, Data
//Scaffold-DbContext "Name=connectionString" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models -ContextDir Data -Context ApplicationContext
//Actualizar base de datos (estructura)
//Scaffold-DbContext "Name=connectionString" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models -ContextDir Data -Context ApplicationContext -f
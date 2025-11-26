using dotenv.net;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MotoSeguraAPI.Data;
using MotoSeguraAPI.Services;
using MotoSeguraAPI.Services.Analisis;
using MotoSeguraAPI.Services.Historial;
using MotoSeguraAPI.Services.Interfaces;
using MotoSeguraAPI.Services.Interfaces.Analisis;
using MotoSeguraAPI.Services.TrayectoService;
using MotoSeguraAPI.Validators;
using System.Text;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

// ===========================================
// 🧱 FACTORIZACIÓN
// ===========================================
builder.ConfigureKestrelServer();
builder.ConfigureJwtAuth();
builder.ConfigureDatabase();
builder.ConfigureSwagger();
builder.ConfigureCors();
builder.ConfigureAppServices();
builder.ConfigureFluentValidation();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// ===========================================
// 🧱 PIPELINE
// ===========================================
await app.CheckDatabaseConnection();

app.UseRouting();
app.UseCors("FrontendPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// Debug Authorization header
app.Use(async (context, next) =>
{
    Console.WriteLine($"🧪 Authorization Header: {context.Request.Headers["Authorization"]}");
    await next();
});

app.MapControllers();
await app.RunAsync();

public partial class Program { }

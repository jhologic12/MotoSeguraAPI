using FluentValidation;
using FluentValidation.AspNetCore;
using MotoSeguraAPI.Validators;
using MotoSeguraAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using MotoSeguraAPI.Mappings;

var builder = WebApplication.CreateBuilder(args);

// 🧩 Servicios necesarios
builder.Services.AddControllers();

// 🧰 FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// 🧭 AutoMapper: registra todos los perfiles del ensamblado
builder.Services.AddAutoMapper(typeof(Program));

// 🗃️ Base de datos SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=motosegura.db"));

// 📚 Swagger para documentación de la API
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🚦 Middleware de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
using FluentValidation;
using FluentValidation.AspNetCore;
using MotoSeguraAPI.Validators; 
using MotoSeguraAPI.Data;// Asegúrate de tener esto si tu validador está aquí
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// 🧩 Servicios necesarios
builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<HelmetValidationRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=motosegura.db"));

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
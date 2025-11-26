using dotenv.net;
using MotoSeguraAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

// ===================================================
// 1️⃣ Configuración global (siempre leer variables)
// ===================================================
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// En desarrollo sí cargamos .env
if (builder.Environment.IsDevelopment())
{
    DotEnv.Load();
    Console.WriteLine("🟢 .env cargado (Development)");
}

// ===================================================
// 2️⃣ Extensiones (orden recomendado)
// ===================================================
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

// ===================================================
// 3️⃣ Pipeline
// ===================================================
await app.CheckDatabaseConnection();

app.UseRouting();
app.UseCors("FrontendPolicy");
app.UseAuthentication();
app.UseAuthorization();

// Swagger solo en desarrollo

    app.UseSwagger();
    app.UseSwaggerUI();


app.MapControllers();

await app.RunAsync();

public partial class Program { }

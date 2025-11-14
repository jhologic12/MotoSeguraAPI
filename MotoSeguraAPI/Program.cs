using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using MotoSeguraAPI.Data;
using MotoSeguraAPI.Services;
using MotoSeguraAPI.Services.Interfaces;
using MotoSeguraAPI.Services.Historial;
using MotoSeguraAPI.Validators;
using MotoSeguraApi.Dtos;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// 🌐 Configura Kestrel para HTTP y HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5086); // HTTP
    options.ListenAnyIP(7043, listen =>
    {
        listen.UseHttps("localhost.pfx", "1234");
    });
});

// 🔐 Configuración JWT
var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("JWT Key is missing.");
if (jwtKey.Length < 32)
    throw new InvalidOperationException("JWT Key must be at least 32 characters.");
Console.WriteLine($"🧪 Clave JWT desde configuración: {jwtKey}");

// 🛡️ Autenticación JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    Console.WriteLine($"🔑 Clave JWT usada en middleware: {jwtKey}");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization();

// 🗃️ Base de datos SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=motosegura.db"));

// 🧩 Servicios base
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));

// ✅ Validaciones con FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<TrayectoValidator>();

// 🧰 Servicios personalizados
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<HistorialUsuarioService>();

// 📚 Swagger con soporte para JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// 🌍 CORS para frontend móvil
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("https://192.168.1.1:4173",
                            "http://10.0.2.2:4173",
                            "http://192.168.1.1:4173",
                            "https://192.168.1.1:5173",
                            "https://localhost:5086")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// 🚦 Middleware en orden correcto
app.UseRouting(); // ✅ necesario para CORS
app.UseCors("PermitirFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// 🧪 Log de encabezado Authorization
app.Use(async (context, next) =>
{
    var authHeader = context.Request.Headers["Authorization"].ToString();
    Console.WriteLine($"🧪 Encabezado Authorization recibido: {authHeader}");
    await next();
});

app.MapControllers();

await app.RunAsync();
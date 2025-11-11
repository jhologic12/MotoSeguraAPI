using FluentValidation.AspNetCore;
using MotoSeguraAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MotoSeguraAPI.Validators;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation;
using MotoSeguraAPI.Services.Interfaces;
using MotoSeguraApi.Dtos;
using Microsoft.OpenApi.Models;
using MotoSeguraAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// 🧩 Servicios base
builder.Services.AddControllers();

// ✅ FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<TrayectoValidator>();

// 🧭 AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// 🗃️ Base de datos SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=motosegura.db"));

// 🔐 Configuración JWT
var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("JWT Key is missing.");
if (jwtKey.Length < 32)
    throw new InvalidOperationException("JWT Key must be at least 32 characters.");

Console.WriteLine($"🧪 Clave JWT desde configuración: {jwtKey}");

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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!))
    };
});

builder.Services.AddAuthorization();

// 🧰 Servicios personalizados
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IUserService, UserService>();

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

var app = builder.Build();

// 🚦 Middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    var authHeader = context.Request.Headers["Authorization"].ToString();
    Console.WriteLine($"🧪 Encabezado Authorization recibido: {authHeader}");
    await next();
});


app.UseAuthentication(); // ✅ debe ir antes
app.UseAuthorization();

app.MapControllers(); // ✅ debe ir después

await app.RunAsync();
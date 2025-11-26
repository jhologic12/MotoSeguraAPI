using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MotoSeguraAPI.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Text;
using MotoSeguraAPI.Services;
using MotoSeguraAPI.Services.Interfaces;
using MotoSeguraAPI.Services.Analisis;
using MotoSeguraAPI.Services.Historial;
using MotoSeguraAPI.Services.TrayectoService;
using MotoSeguraAPI.Validators;

public static class BuilderExtensions
{
    // 🔵 CONFIG KESTREL PARA RENDER
    public static WebApplicationBuilder ConfigureKestrelServer(this WebApplicationBuilder builder)
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(int.Parse(port), listenOptions =>
        {
            // 🔥 Necesario para Swagger y para UI HTTP
            listenOptions.Protocols =
                Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1AndHttp2;
        });
    });

    return builder;
}


    // 🔐 JWT AUTH
    public static WebApplicationBuilder ConfigureJwtAuth(this WebApplicationBuilder builder)
    {
        var jwtKey =
            Environment.GetEnvironmentVariable("Jwt__Key")
            ?? builder.Configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("JWT Key is missing.");

        if (jwtKey.Length < 32)
            throw new InvalidOperationException("JWT key must be >= 32 chars.");

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
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

        return builder;
    }

    // 🗃 BASE DE DATOS (Render + Neon + local)
    public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString =
            Environment.GetEnvironmentVariable("DefaultConnection")
            ?? builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("No connection string found.");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        return builder;
    }

    // 📘 SWAGGER SOLO DEV
    public static WebApplicationBuilder ConfigureSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Bearer token",
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

        return builder;
    }

    // 🌍 CORS Compatible con Android, iOS, Web, Emuladores
    public static WebApplicationBuilder ConfigureCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("FrontendPolicy", policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(_ => true)   // Permite TODO en móviles / Render / local
                    .AllowCredentials();
            });
        });

        return builder;
    }

    // 🧩 Servicios
    public static WebApplicationBuilder ConfigureAppServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<JwtService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAnalizadorTrayectoService, AnalizadorTrayectoService>();
        builder.Services.AddScoped<IHistorialUsuarioService, HistorialUsuarioService>();
        builder.Services.AddScoped<ITrayectoService, TrayectoService>();

        return builder;
    }

    // 📝 VALIDACIONES
    public static WebApplicationBuilder ConfigureFluentValidation(this WebApplicationBuilder builder)
    {
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddFluentValidationClientsideAdapters();
        builder.Services.AddValidatorsFromAssemblyContaining<TrayectoValidator>();

        return builder;
    }

    // 🧪 TEST DE CONEXIÓN
    public static async Task CheckDatabaseConnection(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        try
        {
            if (await db.Database.CanConnectAsync())
                Console.WriteLine("🎉 Conexión a Postgres exitosa");
            else
                Console.WriteLine("⚠ No se pudo conectar a Postgres");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error de conexión: {ex.Message}");
        }
    }
}

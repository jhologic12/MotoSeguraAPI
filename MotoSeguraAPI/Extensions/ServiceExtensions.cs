using MotoSeguraAPI.Services;
using MotoSeguraAPI.Services.Analisis;
using MotoSeguraAPI.Services.Historial;
using MotoSeguraAPI.Services.Interfaces;
using MotoSeguraAPI.Services.Interfaces.Analisis;
using MotoSeguraAPI.Services.TrayectoService;

public static class ServiceExtensions
{
    public static void ConfigureAppServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<JwtService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IHistorialUsuarioService, HistorialUsuarioService>();
        builder.Services.AddScoped<ITrayectoService, TrayectoService>();
        builder.Services.AddScoped<MotoSeguraAPI.Services.Analisis.IAnalizadorTrayectoService, AnalizadorTrayectoService>();
    }
}

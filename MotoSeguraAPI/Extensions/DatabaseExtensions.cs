using Microsoft.EntityFrameworkCore;
using MotoSeguraAPI.Data;

public static class DatabaseExtensions
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString =
            Environment.GetEnvironmentVariable("DefaultConnection") ??
            builder.Configuration.GetConnectionString("DefaultConnection") ??
            throw new("❌ No se encontró cadena de conexión");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));
    }

    public static async Task CheckDatabaseConnection(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        try
        {
            if (await db.Database.CanConnectAsync())
            {
                Console.WriteLine("🎉 Conexión a NEON exitosa.");
            }
            else
            {
                Console.WriteLine("⚠️ No se pudo conectar a NEON.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error BD: {ex.Message}");
        }
    }
}

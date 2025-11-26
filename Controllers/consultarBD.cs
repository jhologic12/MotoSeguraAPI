using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoSeguraAPI.Data;

[ApiController]
[Route("api/[controller]")]
public class DiagnosticoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DiagnosticoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("db-version")]
    public async Task<IActionResult> GetDbVersion()
    {
        var provider = _context.Database.ProviderName ?? string.Empty;

        await using var connection = _context.Database.GetDbConnection();
        await connection.OpenAsync();

        await using var command = connection.CreateCommand();

        command.CommandText = provider switch
        {
            var p when p.Contains("Sqlite", StringComparison.OrdinalIgnoreCase) => "SELECT sqlite_version();",
            var p when p.Contains("Npgsql", StringComparison.OrdinalIgnoreCase) => "SELECT version();",
            _ => string.Empty
        };

        if (string.IsNullOrEmpty(command.CommandText))
            return BadRequest("Proveedor de base de datos no soportado.");

        var version = await command.ExecuteScalarAsync();

        return Ok(new
        {
            Provider = provider,
            Version = version?.ToString() ?? "Desconocida"
        });
    }
}
using MotoSeguraAPI.Data;
using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Models;
using MotoSeguraAPI.Services.Normativa;
using MotoSeguraAPI.Services.Gamificacion;  // ✅ AGREGAR
using MotoSeguraAPI.Services.Educacion;     // ✅ AGREGAR
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MotoSeguraAPI.Services.Interfaces;

namespace MotoSeguraAPI.Services.Historial
{
    public class HistorialUsuarioService : IHistorialUsuarioService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HistorialUsuarioService> _logger;

        public HistorialUsuarioService(
            ApplicationDbContext context,
            ILogger<HistorialUsuarioService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<HistorialUsuarioDto> ObtenerHistorialAsync(Guid userId)
        {
            var usuario = await _context.Users
        .Include(u => u.Trayectos)  // ✅ Esto solo carga propiedades básicas
        .FirstOrDefaultAsync(u => u.Id == userId);

    if (usuario is null)
    {
        _logger.LogWarning("Usuario {UserId} no encontrado al obtener historial", userId);
        throw new KeyNotFoundException("Usuario no encontrado");
    }

    // ✅ CARGAR EXPLÍCITAMENTE todas las propiedades necesarias
    foreach (var trayecto in usuario.Trayectos)
    {
        await _context.Entry(trayecto)
            .Reference(t => t.VerificacionCasco)
            .LoadAsync();
            
        await _context.Entry(trayecto)
            .Collection(t => t.Eventos)
            .LoadAsync();
    }

    var trayectosAnalizados = usuario.Trayectos
        .OrderByDescending(t => t.FechaFin)
        .Select(trayecto =>
        {
            // LOG DIAGNÓSTICO
            Console.WriteLine($"🎯 Procesando trayecto ID: {trayecto.Id}");
            Console.WriteLine($"📊 VelocidadPromedio: {trayecto.VelocidadPromedioKmH}, Distancia: {trayecto.DistanciaRecorridaKm}");
            Console.WriteLine($"📊 VelocidadMaxima: {trayecto.VelocidadMaximaKmH}, Frenadas: {trayecto.FrenadasFuertes}");
            Console.WriteLine($"📊 Aceleracion: {trayecto.AceleracionPromedio}, Giros: {trayecto.GirosBruscos}");
            Console.WriteLine($"📊 Casco: {trayecto.VerificacionCasco?.CascoDetectado}, Eventos: {trayecto.Eventos?.Count}");

            var resultadoNormativo = EvaluadorNormativo.Evaluar(trayecto);
            var medallas = RecompensaService.EvaluarMedallas(trayecto, usuario);
            var sugerencias = ContenidoEducativoService.Sugerir(trayecto);

            Console.WriteLine($"🎖️ Medallas: {medallas.Count} - {string.Join(", ", medallas)}");
            Console.WriteLine($"💡 Sugerencias: {sugerencias.Count} - {string.Join(", ", sugerencias)}");
            Console.WriteLine("---");

            return new TrayectoAnalizadoDto
            {
                CumpleNormas = resultadoNormativo.CumpleNormas,
                InfraccionesNormativas = resultadoNormativo.Infracciones,
                MedallasDesbloqueadas = medallas,
                SugerenciasEducativas = sugerencias,
                AceleracionPromedio = trayecto.AceleracionPromedio,
                FrenadasFuertes = trayecto.FrenadasFuertes,
                GirosBruscos = trayecto.GirosBruscos,
                ExcesosVelocidad = trayecto.ExcesoVelocidad
            };
        }).ToList();

    return new HistorialUsuarioDto
    {
        UserId = usuario.Id,
        Nombre = usuario.Name,
        Trayectos = trayectosAnalizados
    };
        }
    }
}
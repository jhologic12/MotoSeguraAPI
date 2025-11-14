using MotoSeguraAPI.Data;
using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Models;
using MotoSeguraAPI.Services.Normativa;
using MotoSeguraAPI.Services.Gamificacion;
using MotoSeguraAPI.Services.Educacion;
using Microsoft.EntityFrameworkCore;

namespace MotoSeguraAPI.Services.Historial
{
    public class HistorialUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public HistorialUsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public HistorialUsuarioDto ObtenerHistorial(Guid userId)
        {
            var usuario = _context.Users
                .Include(u => u.Trayectos)
                .FirstOrDefault(u => u.Id == userId);

            if (usuario is null)
                throw  new KeyNotFoundException("Usuario no encontrado");

            var trayectosAnalizados = usuario.Trayectos
                .OrderByDescending(t => t.FechaFin)
                .Select(t =>
                {
                    var cumpleNormas = EvaluadorNormativo.CumpleNormas(t);
                    var medallas = RecompensaService.EvaluarMedallas(t, usuario);
                    var sugerencias = cumpleNormas ? new List<string>() : ContenidoEducativoService.Sugerir(t);

                    return new TrayectoAnalizadoDto
                    {
                        CumpleNormas = cumpleNormas,
                        MedallasDesbloqueadas = medallas,
                        SugerenciasEducativas = sugerencias,
                        AceleracionPromedio = t.AceleracionPromedio,
                        FrenadasFuertes = t.FrenadasFuertes,
                        GirosBruscos = t.GirosBruscos,
                        ExcesosVelocidad = t.ExcesoVelocidad
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
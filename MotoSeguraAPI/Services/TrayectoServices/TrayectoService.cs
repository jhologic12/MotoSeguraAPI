using MotoSeguraAPI.Data;
using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Models;
using MotoSeguraAPI.Services.Analisis;
using MotoSeguraAPI.Services.Normativa;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MotoSeguraAPI.Services.Interfaces;
using MotoSeguraAPI.Services.Gamificacion;
using MotoSeguraAPI.Services.Educacion;

namespace MotoSeguraAPI.Services.TrayectoService
{
    public class TrayectoService : ITrayectoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAnalizadorTrayectoService _analizador;

        // ✅ CONSTRUCTOR SIMPLIFICADO - solo servicios registrados
        public TrayectoService(
            ApplicationDbContext context,
            IMapper mapper,
            IAnalizadorTrayectoService analizador) // ✅ USA LA INTERFAZ
        {
            _context = context;
            _mapper = mapper;
            _analizador = analizador;
        }

        public async Task<TrayectoAnalizadoDto> ProcesarTrayectoFinalizado(TrayectoDto dto, Guid userId)
        {
            var trayecto = _mapper.Map<Trayecto>(dto);
            trayecto.UserId = userId;

            trayecto = _analizador.EnriquecerTrayecto(trayecto, dto);

            _context.Trayectos.Add(trayecto);
            await _context.SaveChangesAsync();

            // ✅ USA CLASES ESTÁTICAS DIRECTAMENTE
            var resultadoNormativo = EvaluadorNormativo.Evaluar(trayecto);
            var usuario = await _context.Users.FindAsync(userId);

            // ✅ LISTAS VACÍAS TEMPORALES para servicios no implementados
            var medallas =  RecompensaService.EvaluarMedallas(trayecto, usuario);
            var sugerencias = ContenidoEducativoService.Sugerir(trayecto);

            return new TrayectoAnalizadoDto
            {
                CumpleNormas = resultadoNormativo.CumpleNormas,
                InfraccionesNormativas = resultadoNormativo.Infracciones,
                MedallasDesbloqueadas = medallas, // ✅ LISTA VACÍA TEMPORAL
                SugerenciasEducativas = sugerencias, // ✅ LISTA VACÍA TEMPORAL
                AceleracionPromedio = trayecto.AceleracionPromedio,
                FrenadasFuertes = trayecto.FrenadasFuertes,
                GirosBruscos = trayecto.GirosBruscos,
                ExcesosVelocidad = trayecto.ExcesoVelocidad
            };
        }

        public async Task<HistorialUsuarioResumenDto> ObtenerHistorialResumidoAsync(Guid userId)
        {
            var historial = await _context.Trayectos
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.FechaFin)
                .Select(t => new TrayectoResumenDto
                {
                    Id = t.Id,
                    FechaInicio = t.FechaInicio,
                    FechaFin = t.FechaFin,
                    DistanciaRecorridaKm = t.DistanciaRecorridaKm,
                    VelocidadPromedioKmH = t.VelocidadPromedioKmH,
                    VelocidadMaximaKmH = t.VelocidadMaximaKmH,
                    ModoConduccion = t.ModoConduccion,
                    Eventos = t.Eventos.Count,
                    CascoDetectado = t.VerificacionCasco.CascoDetectado
                })
                .ToListAsync();

            return new HistorialUsuarioResumenDto
            {
                UserId = userId,
                Nombre = _context.Users.Find(userId)?.Name ?? string.Empty,
                Trayectos = historial
            };
        }
    }
}
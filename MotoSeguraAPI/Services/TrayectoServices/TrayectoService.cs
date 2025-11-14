using MotoSeguraAPI.Models;
using MotoSeguraApi.Dtos;
using MotoSeguraAPI.Services.Analisis;
using MotoSeguraAPI.Services.Normativa;
using MotoSeguraAPI.Services.Gamificacion;
using MotoSeguraAPI.Services.Educacion;
using MotoSeguraAPI.Data;
using AutoMapper;
using MotoSeguraAPI.Dtos;

namespace MotoSeguraAPI.Services.TrayectoService
{
    public class TrayectoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TrayectoService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TrayectoAnalizadoDto ProcesarTrayectoFinalizado(TrayectoDto dto, Guid userId)
        {
            var trayecto = _mapper.Map<Models.Trayecto>(dto);
            trayecto.UserId = userId;

            trayecto = AnalizadorTrayectoService.EnriquecerTrayecto(trayecto, dto);

            _context.Trayectos.Add(trayecto);
            _context.SaveChanges();

            var cumpleNormas = EvaluadorNormativo.CumpleNormas(trayecto);

            var usuario = _context.Users.Find(userId);
            var medallas = usuario is not null
                ? RecompensaService.EvaluarMedallas(trayecto, usuario)
                : new List<string>();

            var sugerencias = cumpleNormas ? new List<string>() : ContenidoEducativoService.Sugerir(trayecto);

            return new TrayectoAnalizadoDto
            {
                CumpleNormas = cumpleNormas,
                MedallasDesbloqueadas = medallas,
                SugerenciasEducativas = sugerencias,
                AceleracionPromedio = trayecto.AceleracionPromedio,
                FrenadasFuertes = trayecto.FrenadasFuertes,
                GirosBruscos = trayecto.GirosBruscos,
                ExcesosVelocidad = trayecto.ExcesoVelocidad
            };
        }
    }
}
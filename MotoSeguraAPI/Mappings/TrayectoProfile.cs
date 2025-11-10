using AutoMapper;
using MotoSeguraAPI.Models.SubModels;
using MotoSeguraApi.Models;
using MotoSeguraApi.Dtos;
using MotoSeguraAPI.Models;
using MotoSeguraApi.Models.SubModels;

namespace MotoSeguraAPI.Mappings
{
    public class TrayectoProfile : Profile
    {
        public TrayectoProfile()
        {
            CreateMap<TrayectoDto, Trayecto>();
            CreateMap<CoordenadasDto, Coordenadas>();
            CreateMap<GpsDto, Gps>();
            CreateMap<AcelerometroDto, Acelerometro>();
            CreateMap<GiroscopioDto, Giroscopio>();
            CreateMap<ConectividadDto, Conectividad>();
            CreateMap<VerificacionCascoDto, VerificacionCasco>();
            CreateMap<EventoDetectadoDto, Evento>();
        }
    }
}

using AutoMapper;
using MotoSeguraAPI.Models.SubModels;
using MotoSeguraApi.Models;
using MotoSeguraAPI.Dtos;
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
            CreateMap<VerificacionCascoDto, VerificacionCasco>()
     .ForMember(dest => dest.CascoDetectado, opt => opt.MapFrom(src => src.Casco_Detectado));
     CreateMap<Trayecto, TrayectoResumenDto>()
    .ForMember(dest => dest.Eventos, opt => opt.MapFrom(src => src.Eventos.Count))
    .ForMember(dest => dest.CascoDetectado, opt => opt.MapFrom(src => src.VerificacionCasco.CascoDetectado));


            CreateMap<EventoDetectadoDto, Evento>();
        }
    }
}

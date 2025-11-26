using System.ComponentModel.DataAnnotations;


namespace MotoSeguraAPI.Dtos
{
    public class TrayectoDto
    {

       

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double DistanciaRecorridaKm { get; set; }
        public double VelocidadPromedioKmH { get; set; }
        public double VelocidadMaximaKmH { get; set; }
        public string ModoConduccion { get; set; } = string.Empty;

        public CoordenadasDto UbicacionInicio { get; set; } = new();
        public CoordenadasDto? UbicacionFin { get; set; }

        public GpsDto Gps { get; set; } = new();
        public AcelerometroDto Acelerometro { get; set; } = new();
        public GiroscopioDto Giroscopio { get; set; } = new();
        public ConectividadDto Conectividad { get; set; } = new();

        public List<EventoDetectadoDto> Eventos { get; set; } = new();
        public VerificacionCascoDto VerificacionCasco { get; set; } = new();
    }
}
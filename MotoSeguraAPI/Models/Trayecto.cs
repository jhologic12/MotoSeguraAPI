using MotoSeguraApi.Models.SubModels;
using MotoSeguraAPI.Models.SubModels;

namespace MotoSeguraAPI.Models

{
    public class Trayecto
    {
        public Guid Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double DistanciaRecorridaKm { get; set; }
        public double VelocidadPromedioKmH { get; set; }
        public double VelocidadMaximaKmH { get; set; }
        public required string ModoConduccion { get; set; }

        public required Coordenadas UbicacionInicio { get; set; }
        public Coordenadas? UbicacionFin { get; set; }

        public required Gps Gps { get; set; }
        public required Acelerometro Acelerometro { get; set; }
        public  required Giroscopio Giroscopio { get; set; }
        public required Conectividad Conectividad { get; set; }
        public required VerificacionCasco VerificacionCasco { get; set; }

        public List<Evento> Eventos { get; set; } = new();
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
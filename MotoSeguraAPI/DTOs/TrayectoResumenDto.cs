namespace MotoSeguraApi.Dtos
{
    public class TrayectoResumenDto
    {
        public Guid Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double DistanciaRecorridaKm { get; set; }
        public double VelocidadPromedioKmH { get; set; }
        public double VelocidadMaximaKmH { get; set; }
        public string ModoConduccion { get; set; } = string.Empty;
        public int Eventos { get; set; }
        public bool CascoDetectado { get; set; }
    }
}
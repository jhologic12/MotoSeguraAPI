namespace MotoSeguraAPI.Dtos
{
    public class TrayectoAnalizadoDto
    {
        public bool CumpleNormas { get; set; }
        public List<string> MedallasDesbloqueadas { get; set; } = new();
        public List<string> SugerenciasEducativas { get; set; } = new();
        public double AceleracionPromedio { get; set; }
        public int FrenadasFuertes { get; set; }
        public int GirosBruscos { get; set; }
        public int ExcesosVelocidad { get; set; }
    }
}
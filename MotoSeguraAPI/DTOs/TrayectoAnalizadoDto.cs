namespace MotoSeguraAPI.Dtos
{
    public class TrayectoAnalizadoDto
    {
        // 🧠 Evaluación normativa
        public bool CumpleNormas { get; set; }
        public List<string> InfraccionesNormativas { get; set; } = new();

        // 🏅 Gamificación
        public List<string> MedallasDesbloqueadas { get; set; } = new();

        // 📚 Educación vial
        public List<string> SugerenciasEducativas { get; set; } = new();

        // 📊 Métricas del trayecto
        public double AceleracionPromedio { get; set; }
        public int FrenadasFuertes { get; set; }
        public int GirosBruscos { get; set; }
        public int ExcesosVelocidad { get; set; }
    }
}
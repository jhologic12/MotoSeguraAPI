namespace MotoSeguraAPI.Models.SubModels
{
    public class ResultadoNormativo
    {
        public bool CumpleNormas { get; set; }
        public List<string> Infracciones { get; set; } = new();
    }
}
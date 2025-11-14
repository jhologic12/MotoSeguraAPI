using System.Text.Json.Serialization;

namespace MotoSeguraApi.Models.SubModels
{
    public class VerificacionCasco
    {
        [JsonPropertyName("fotoCasco")]
        public string FotoCasco { get; set; } = string.Empty;

        [JsonPropertyName("casco_Detectado")]
        public bool CascoDetectado { get; set; }
    }
}
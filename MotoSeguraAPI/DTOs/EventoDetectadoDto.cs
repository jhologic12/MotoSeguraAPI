namespace MotoSeguraAPI.Dtos
{
    public class EventoDetectadoDto
{
    public string Tipo { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public string? Detalles { get; set; }
}
}
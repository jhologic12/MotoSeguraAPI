using MotoSeguraAPI.Dtos;

public class HistorialUsuarioDto
{
    public Guid UserId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public List<TrayectoAnalizadoDto> Trayectos { get; set; } = new();
}
namespace MotoSeguraAPI.Dtos
{
    public class HistorialUsuarioResumenDto
    {
        public Guid UserId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public List<TrayectoResumenDto> Trayectos { get; set; } = new();
    }

  
}
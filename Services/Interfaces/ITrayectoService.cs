using MotoSeguraAPI.Dtos;

namespace MotoSeguraAPI.Services.Interfaces
{
    public interface ITrayectoService
    {
        /// <summary>
        /// Procesa un trayecto finalizado y devuelve el análisis completo.
        /// </summary>
        Task<TrayectoAnalizadoDto> ProcesarTrayectoFinalizado(TrayectoDto dto, Guid userId);

        /// <summary>
        /// Obtiene el historial resumido de trayectos de un usuario.
        /// </summary>
        Task<HistorialUsuarioResumenDto> ObtenerHistorialResumidoAsync(Guid userId);
    }
}
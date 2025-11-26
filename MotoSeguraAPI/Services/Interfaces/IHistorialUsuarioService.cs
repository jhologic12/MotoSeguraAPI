// ACTUALIZA la interfaz en Services/Interfaces/IHistorialUsuarioService.cs
using MotoSeguraAPI.Dtos;

namespace MotoSeguraAPI.Services.Interfaces
{
    public interface IHistorialUsuarioService
    {
        Task<HistorialUsuarioDto> ObtenerHistorialAsync(Guid userId);
    }
}
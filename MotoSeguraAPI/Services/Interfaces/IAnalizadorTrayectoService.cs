using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Models;

namespace MotoSeguraAPI.Services.Interfaces.Analisis
{
    public interface IAnalizadorTrayectoService
    {
        Trayecto EnriquecerTrayecto(Trayecto trayecto, TrayectoDto dto);
    }
}

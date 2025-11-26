using MotoSeguraAPI.Models;

namespace MotoSeguraAPI.Services.Educacion
{
    public interface IContenidoEducativoService
    {
        List<string> Sugerir(Trayecto trayecto);
    }
}

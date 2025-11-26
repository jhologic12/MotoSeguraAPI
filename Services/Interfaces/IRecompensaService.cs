using MotoSeguraAPI.Models;

namespace MotoSeguraAPI.Services.Gamificacion
{
    public interface IRecompensaService
    {
        List<string> EvaluarMedallas(Trayecto trayecto, User usuario);
    }
}


using MotoSeguraAPI.Models;
using MotoSeguraAPI.Models.SubModels;

namespace MotoSeguraAPI.Services.Normativa
{
    public interface IEvaluadorNormativo
    {
        ResultadoNormativo Evaluar(Trayecto trayecto);
    }
}


using MotoSeguraAPI.Models;
using MotoSeguraAPI.Services.Normativa;

namespace MotoSeguraAPI.Services.Gamificacion
{
    public static class RecompensaService
    {
        public static List<string> EvaluarMedallas(Trayecto trayecto, User usuario)
        {
            var medallas = new List<string>();

            if (EvaluadorNormativo.CumpleNormas(trayecto))
                medallas.Add("🛡️ Conductor Seguro");

            // Puedes agregar lógica adicional basada en historial

            return medallas;
        }
    }
}
using MotoSeguraAPI.Models;
using MotoSeguraApi.Models.SubModels;

namespace MotoSeguraAPI.Services.Normativa
{
    public static class EvaluadorNormativo
    {
        public static bool CumpleNormas(Trayecto trayecto)
        {
            return trayecto.VelocidadPromedioKmH <= NormasTransitoColombia.VelocidadMaximaUrbana &&
                   trayecto.AceleracionPromedio <= NormasTransitoColombia.AceleracionMaximaSegura &&
                   trayecto.FrenadasFuertes <= NormasTransitoColombia.MaxFrenadasFuertes &&
                   trayecto.GirosBruscos <= NormasTransitoColombia.MaxGirosBruscos &&
                   trayecto.ExcesoVelocidad <= NormasTransitoColombia.MaxExcesosVelocidad;
        }
    }
}
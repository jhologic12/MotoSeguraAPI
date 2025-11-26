using MotoSeguraAPI.Models;
using MotoSeguraAPI.Models.SubModels;
using System.Linq;

namespace MotoSeguraAPI.Services.Normativa
{
    public static class EvaluadorNormativo
    {
        public static ResultadoNormativo Evaluar(Trayecto trayecto)
        {
            var resultado = new ResultadoNormativo();

            // 1. Velocidad máxima en zona urbana
            if (trayecto.VelocidadMaximaKmH > NormasTransitoColombia.VelocidadMaximaUrbana)
            {
                resultado.Infracciones.Add($"Exceso de velocidad máxima: {trayecto.VelocidadMaximaKmH} km/h (Límite: {NormasTransitoColombia.VelocidadMaximaUrbana} km/h)");
            }

            // 2. Velocidad promedio muy alta para zona urbana
            if (trayecto.VelocidadPromedioKmH > 50) // Más estricto que el máximo
            {
                resultado.Infracciones.Add($"Velocidad promedio muy alta para zona urbana: {trayecto.VelocidadPromedioKmH} km/h");
            }

            // 3. Aceleración brusca (valor absoluto para detectar tanto aceleración como frenado brusco)
            if (Math.Abs(trayecto.AceleracionPromedio) > NormasTransitoColombia.AceleracionMaximaSegura)
            {
                resultado.Infracciones.Add($"Aceleración/Frenado brusco detectado: {trayecto.AceleracionPromedio:F2} m/s²");
            }

            // 4. Frenadas fuertes
            if (trayecto.FrenadasFuertes > NormasTransitoColombia.MaxFrenadasFuertes)
            {
                resultado.Infracciones.Add($"Demasiadas frenadas bruscas: {trayecto.FrenadasFuertes} (Límite: {NormasTransitoColombia.MaxFrenadasFuertes})");
            }

            // 5. Giros bruscos
            if (trayecto.GirosBruscos > NormasTransitoColombia.MaxGirosBruscos)
            {
                resultado.Infracciones.Add($"Demasiados giros bruscos: {trayecto.GirosBruscos} (Límite: {NormasTransitoColombia.MaxGirosBruscos})");
            }

            // 6. Excesos de velocidad (cualquier exceso es infracción)
            if (trayecto.ExcesoVelocidad > NormasTransitoColombia.MaxExcesosVelocidad)
            {
                resultado.Infracciones.Add($"Excesos de velocidad detectados: {trayecto.ExcesoVelocidad}");
            }

            // 7. Casco - verificación robusta
            if (trayecto.VerificacionCasco == null)
            {
                resultado.Infracciones.Add("No se pudo verificar el uso de casco");
            }
            else if (!trayecto.VerificacionCasco.CascoDetectado)
            {
                resultado.Infracciones.Add("Conducción sin casco detectado - Infracción grave");
            }

            // 8. Nuevas validaciones más realistas
            if (trayecto.Eventos != null && trayecto.Eventos.Count > 10)
            {
                resultado.Infracciones.Add($"Demasiados eventos de conducción riesgosa: {trayecto.Eventos.Count}");
            }

            resultado.CumpleNormas = resultado.Infracciones.Count == 0;
            return resultado;
        }
    }
}
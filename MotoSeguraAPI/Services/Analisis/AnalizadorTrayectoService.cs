using MotoSeguraApi.Dtos;
using MotoSeguraAPI.Models;

namespace MotoSeguraAPI.Services.Analisis
{
    public static class AnalizadorTrayectoService
    {
        public static Trayecto EnriquecerTrayecto(Trayecto trayecto, TrayectoDto dto)
        {
            // Simulación de cálculo (reemplazar con lógica real)
            trayecto.AceleracionPromedio = CalcularAceleracion(dto);
            trayecto.FrenadasFuertes = ContarFrenadas(dto);
            trayecto.GirosBruscos = ContarGiros(dto);
            trayecto.ExcesoVelocidad = ContarExcesos(dto);

            return trayecto;
        }

        private static double CalcularAceleracion(TrayectoDto dto)

        {

        
           
            return dto.Acelerometro.Aceleracion;

        }

        private static int ContarFrenadas(TrayectoDto dto)
        {

            
            // Detectar caídas abruptas de velocidad
            return 2;
        }

        private static int ContarGiros(TrayectoDto dto)
        {
            // Detectar cambios bruscos de dirección
            return 1;
        }

        private static int ContarExcesos(TrayectoDto dto)
        {
            // Comparar muestras de velocidad con umbral legal
            return 0;
        }
    }
}
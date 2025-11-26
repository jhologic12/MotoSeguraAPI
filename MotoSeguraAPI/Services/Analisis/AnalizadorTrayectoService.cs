using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Models;

namespace MotoSeguraAPI.Services.Analisis
{
    /// <summary>
    /// Servicio encargado de enriquecer un trayecto con métricas calculadas.
    /// </summary>
    public class AnalizadorTrayectoService : IAnalizadorTrayectoService
    {
        public Trayecto EnriquecerTrayecto(Trayecto trayecto, TrayectoDto dto)
        {
            trayecto.AceleracionPromedio = CalcularAceleracion(dto);
            trayecto.FrenadasFuertes = ContarFrenadas(dto);
            trayecto.GirosBruscos = ContarGiros(dto);
            trayecto.ExcesoVelocidad = ContarExcesos(dto);

            return trayecto;
        }

        private double CalcularAceleracion(TrayectoDto dto)
        {
            // Validar que el acelerómetro no sea null
            if (dto.Acelerometro == null)
                return 0.0;

            return dto.Acelerometro.Aceleracion;
        }

        private int ContarFrenadas(TrayectoDto dto)
        {
            // TODO: Implementar lógica real de detección de frenadas fuertes
            // Ejemplo: comparar variaciones de velocidad entre muestras
            return 2;
        }

        private int ContarGiros(TrayectoDto dto)
        {
            // TODO: Implementar lógica real de detección de giros bruscos
            return 1;
        }

        private int ContarExcesos(TrayectoDto dto)
        {
            // TODO: Implementar lógica real de detección de excesos de velocidad
            return 0;
        }
    }

    /// <summary>
    /// Interfaz para permitir mocking y pruebas unitarias.
    /// </summary>
    public interface IAnalizadorTrayectoService
    {
        Trayecto EnriquecerTrayecto(Trayecto trayecto, TrayectoDto dto);
    }
}
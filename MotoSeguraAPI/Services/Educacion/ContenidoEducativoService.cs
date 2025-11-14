using MotoSeguraAPI.Models;

namespace MotoSeguraAPI.Services.Educacion
{
    public static class ContenidoEducativoService
    {
        public static List<string> Sugerir(Trayecto trayecto)
        {
            var sugerencias = new List<string>();

            if (trayecto.ExcesoVelocidad > 0)
                sugerencias.Add("🎥 Video: Cómo evitar el exceso de velocidad");

            if (trayecto.FrenadasFuertes > 3)
                sugerencias.Add("📘 Infografía: Técnicas de frenado progresivo");

            return sugerencias;
        }
    }
}
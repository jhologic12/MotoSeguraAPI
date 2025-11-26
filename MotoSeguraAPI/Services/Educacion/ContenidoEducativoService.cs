using MotoSeguraAPI.Models;
using System.Collections.Generic;

namespace MotoSeguraAPI.Services.Educacion
{
    public static class ContenidoEducativoService
    {
        public static List<string> Sugerir(Trayecto trayecto)
        {
            var sugerencias = new List<string>();
            
            if (trayecto.VelocidadMaximaKmH > 60)
                sugerencias.Add("Considera reducir tu velocidad máxima en zonas urbanas");
                
            if (trayecto.FrenadasFuertes > 3)
                sugerencias.Add("Practica técnicas de frenado anticipado para mayor seguridad");
                
            if (trayecto.GirosBruscos > 2)
                sugerencias.Add("Realiza los giros con mayor suavidad para mejorar la estabilidad");
                
            if (trayecto.AceleracionPromedio > 0.5)
                sugerencias.Add("Una aceleración más gradual ayuda a ahorrar combustible");
                
            return sugerencias;
        }
    }
}
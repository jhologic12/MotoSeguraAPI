using MotoSeguraAPI.Models;
using MotoSeguraAPI.Services.Normativa;
using System.Collections.Generic;

namespace MotoSeguraAPI.Services.Gamificacion
{
    public static class RecompensaService
    {
        public static List<string> EvaluarMedallas(Trayecto trayecto, User? usuario) // Agregar ? para nullable
        {
          var medallas = new List<string>();
    var resultadoNormativo = EvaluadorNormativo.Evaluar(trayecto);

    // Medallas por comportamiento seguro
    if (resultadoNormativo.CumpleNormas)
        medallas.Add("Conductor Responsable 🏆");
    else if (resultadoNormativo.Infracciones.Count <= 2)
        medallas.Add("Conductor en Mejora 📈");
        
    if (trayecto.VelocidadPromedioKmH <= 50 && trayecto.VelocidadPromedioKmH >= 30)
        medallas.Add("Velocidad Constante ⚡");
        
    if (trayecto.FrenadasFuertes <= 1)
        medallas.Add("Frenado Suave 🛑");
        
    if (trayecto.DistanciaRecorridaKm >= 2)
        medallas.Add($"Viajero ({trayecto.DistanciaRecorridaKm}km) 🗺️");
        
    if (trayecto.DistanciaRecorridaKm >= 5)
        medallas.Add("Viajero Experimentado 🌟");
        
    if (trayecto.GirosBruscos == 0)
        medallas.Add("Giros Precisos 🌀");

    // Medallas especiales
    if (trayecto.VerificacionCasco?.CascoDetectado == true)
        medallas.Add("Casco Protector 🪖");

    // Medallas que requieren usuario
    if (usuario != null)
    {
        medallas.Add("Usuario Verificado ✅");
    }
    
    return medallas;
        }
    }
}
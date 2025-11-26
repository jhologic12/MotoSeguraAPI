

using MotoSeguraAPI.Dtos;

namespace MotoSeguraApi.Models.SubModels
{
    public class Gps
    {
        public CoordenadasDto Ubicacion { get; set; } = new();
        public double Velocidad { get; set; }
        public double Altitud { get; set; }
        public double Direccion { get; set; }
    }


}
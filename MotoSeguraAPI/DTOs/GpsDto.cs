namespace MotoSeguraAPI.Dtos
{
    public class GpsDto
{
        public CoordenadasDto Ubicacion { get; set; } = new();
    public double Velocidad { get; set; }
    public double Altitud { get; set; }
    public double Direccion { get; set; }
}


}
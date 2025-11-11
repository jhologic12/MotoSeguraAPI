using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoSeguraAPI.Models
{
    public class Evento
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Tipo { get; set; } = string.Empty;

        public string? Detalles { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        // Relación con Trayecto
        [ForeignKey("Trayecto")]
        public Guid TrayectoId { get; set; }
        public Trayecto Trayecto { get; set; } = null!;
    }
}
using System.ComponentModel.DataAnnotations;

namespace MotoSeguraAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = null!;


        // Relación con trayectos (si decides implementarla)
        public ICollection<Trayecto> Trayectos { get; set; } = new List<Trayecto>();
    }
}
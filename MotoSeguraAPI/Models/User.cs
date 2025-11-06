
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
        public string HelmetType { get; set; } = string.Empty;
       
        public bool HelmetValidated { get; set; } = false;
    }
}
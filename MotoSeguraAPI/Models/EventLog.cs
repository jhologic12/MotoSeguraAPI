using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoSeguraAPI.Models
{
    public class EventLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public string? Description { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
         public User? User { get; set; }

    }
}
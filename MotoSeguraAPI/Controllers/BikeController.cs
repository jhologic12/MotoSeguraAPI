using Microsoft.AspNetCore.Mvc;
using MotoSeguraAPI.Data;
using MotoSeguraAPI.DTOs;
using MotoSeguraAPI.Models;

namespace MotoSeguraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BikeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BikeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("start")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult StartBike([FromBody] StartBikeRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == request.UserId);
            if (user == null)
                return NotFound("Usuario no encontrado.");

            bool canStart = user.HelmetValidated;

            var log = new EventLog
            {
                Timestamp = DateTime.UtcNow,
                Description = canStart
                    ? $"Moto encendida por {user.Name} (casco validado)"
                    : $"Intento fallido de encendido por {user.Name} (casco no validado)",
                UserId = user.Id
            };

            _context.EventLogs.Add(log);
            _context.SaveChanges();

            return Ok(new
            {
                user.Id,
                user.Name,
                HelmetValidated = user.HelmetValidated,
                CanStart = canStart,
                Message = canStart ? " Moto encendida" : " Casco no validado. No se puede encender la moto."
            });
        }
    }
}
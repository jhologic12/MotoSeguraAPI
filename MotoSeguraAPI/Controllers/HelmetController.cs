using Microsoft.AspNetCore.Mvc;
using MotoSeguraAPI.Data;
using MotoSeguraAPI.Models;
using MotoSeguraAPI.DTOs;
using FluentValidation;
using FluentValidation.Results;

namespace MotoSeguraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelmetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IValidator<HelmetValidationRequest> _validator;

        public HelmetController(ApplicationDbContext context, IValidator<HelmetValidationRequest> validator)
        {
            _context = context;
            _validator = validator;
        }

        [HttpPost("validate")]
        [ProducesResponseType(typeof(HelmetValidationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidateHelmet([FromBody] HelmetValidationRequest request)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new
                {
                    Campo = e.PropertyName,
                    Error = e.ErrorMessage
                });

                return BadRequest(new
                {
                    Mensaje = "Validación fallida",
                    Errores = errors
                });
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                HelmetType = request.HelmetType,
                HelmetValidated = true
            };

            _context.Users.Add(user);

            var log = new EventLog
            {
                Id = Guid.NewGuid(),
                Timestamp = DateTime.UtcNow,
                Description = $"Validación de casco: {user.HelmetType} → válido",
                UserId = user.Id
            };

            _context.EventLogs.Add(log);
            await _context.SaveChangesAsync();

            var response = new HelmetValidationResponse
            {
                Id = user.Id,
                Name = user.Name,
                HelmetType = user.HelmetType,
                HelmetValidated = user.HelmetValidated,
                Message = "Casco válido"
            };

            return Ok(response);
        }
    }
}
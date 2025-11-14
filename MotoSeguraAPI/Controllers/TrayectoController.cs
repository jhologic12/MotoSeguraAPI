using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoSeguraAPI.Data;
using MotoSeguraApi.Dtos;
using MotoSeguraAPI.Models;
using MotoSeguraAPI.Services.Interfaces;
using AutoMapper;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using MotoSeguraAPI.Services.Analisis;

namespace MotoSeguraAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TrayectoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<TrayectoController> _logger;
        private readonly IUserService _userService;

        public TrayectoController(
            ApplicationDbContext context,
            IMapper mapper,
            ILogger<TrayectoController> logger,
            IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult RegistrarTrayecto([FromBody] TrayectoDto dto)
        {
            _logger.LogInformation("✅ Método RegistrarTrayecto ejecutado");

            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim))
            {
                _logger.LogWarning("❌ Token inválido o expirado.");
                return Unauthorized("Token inválido o expirado.");
            }

            if (!Guid.TryParse(userIdClaim, out var userId))
            {
                _logger.LogWarning("❌ Token inválido: no se pudo parsear el userId.");
                return Unauthorized("Token inválido.");
            }

            var user = _userService.FindById(userId);
            if (user == null)
            {
                _logger.LogWarning("❌ Usuario no encontrado en base de datos.");
                return NotFound("Usuario no encontrado.");
            }

            var trayecto = _mapper.Map<Trayecto>(dto);
            trayecto.UserId = userId;
            // Enriquecer con datos calculados
            trayecto = AnalizadorTrayectoService.EnriquecerTrayecto(trayecto, dto);

            _context.Trayectos.Add(trayecto);
            _context.SaveChanges();

            _logger.LogInformation("✅ Trayecto registrado correctamente para el usuario {Email}", user.Email);

            return CreatedAtAction(nameof(RegistrarTrayecto), new { trayecto.Id }, new
            {
                trayecto.Id,
                trayecto.FechaInicio,
                trayecto.ModoConduccion,
                trayecto.Eventos.Count,
                trayecto.VerificacionCasco?.CascoDetectado
            });
        }


        [HttpGet("historial")]
        [Authorize]
        [ProducesResponseType(typeof(List<TrayectoResumenDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public IActionResult GetHistorial()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            {
                _logger.LogWarning("❌ Token inválido o expirado.");
                return Unauthorized("Token inválido o expirado.");
            }

            var trayectos = _context.Trayectos
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.FechaInicio)
                .ToList();

            var resultado = _mapper.Map<List<TrayectoResumenDto>>(trayectos);

            _logger.LogInformation("✅ Historial de trayectos recuperado para el usuario {UserId}", userId);
            return Ok(resultado);
        }

    }
}
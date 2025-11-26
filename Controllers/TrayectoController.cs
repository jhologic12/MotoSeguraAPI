using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoSeguraAPI.Services.Interfaces;
using MotoSeguraAPI.Services.Historial;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using MotoSeguraAPI.Dtos;

namespace MotoSeguraAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TrayectoController : ControllerBase
    {
        private readonly ILogger<TrayectoController> _logger;
        private readonly IUserService _userService;
        private readonly ITrayectoService _trayectoService;
        private readonly IHistorialUsuarioService _historialService;

        public TrayectoController(
            ILogger<TrayectoController> logger,
            IUserService userService,
            ITrayectoService trayectoService,
            IHistorialUsuarioService historialService)
        {
            _logger = logger;
            _userService = userService;
            _trayectoService = trayectoService;
            _historialService = historialService;
        }

        [HttpPost("finalizar")]
        [ProducesResponseType(typeof(TrayectoAnalizadoDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> FinalizarTrayecto([FromBody] TrayectoDto dto)
        {
            _logger.LogInformation("✅ Método FinalizarTrayecto ejecutado");

            var userId = ObtenerUserIdDesdeToken();
            if (userId == null)
            {
                _logger.LogWarning("❌ Token inválido o expirado.");
                return Unauthorized("Token inválido o expirado.");
            }

            var user = _userService.FindById(userId.Value);
            if (user == null)
            {
                _logger.LogWarning("❌ Usuario no encontrado en base de datos.");
                return NotFound("Usuario no encontrado.");
            }

            var resultado = await _trayectoService.ProcesarTrayectoFinalizado(dto, userId.Value);

            _logger.LogInformation("✅ Trayecto procesado y analizado para el usuario {UserId}", userId);
            return CreatedAtAction(nameof(FinalizarTrayecto), new { resultado }, resultado);
        }

        [HttpGet("historial")]
        [ProducesResponseType(typeof(HistorialUsuarioDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetHistorial()
        {
            var userId = ObtenerUserIdDesdeToken();
            if (userId == null)
            {
                _logger.LogWarning("❌ Token inválido o expirado.");
                return Unauthorized("Token inválido o expirado.");
            }

            var historial = await _historialService.ObtenerHistorialAsync(userId.Value);

            _logger.LogInformation("✅ Historial de trayectos recuperado para el usuario {UserId}", userId);
            return Ok(historial);
        }

        private Guid? ObtenerUserIdDesdeToken()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(userIdClaim, out var userId) ? userId : null;
        }
    }
}
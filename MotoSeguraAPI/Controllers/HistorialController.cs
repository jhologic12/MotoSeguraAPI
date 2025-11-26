using Microsoft.AspNetCore.Mvc;
using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Services.Historial;
using MotoSeguraAPI.Services.Interfaces;

namespace MotoSeguraAPI.Controllers
{
    [ApiController]
    [Route("api/usuario/{userId}/historial")]
    public class HistorialController : ControllerBase
    {
        private readonly IHistorialUsuarioService _historialService;

        public HistorialController(IHistorialUsuarioService historialService)
        {
            _historialService = historialService;
        }

        [HttpGet]
        public async Task<ActionResult<HistorialUsuarioDto>> Get(Guid userId)
        {
            try
            {
                var historial = await _historialService.ObtenerHistorialAsync(userId);
                return Ok(historial);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
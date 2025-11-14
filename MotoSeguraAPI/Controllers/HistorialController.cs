using Microsoft.AspNetCore.Mvc;
using MotoSeguraAPI.Dtos;
using MotoSeguraAPI.Services.Historial;

namespace MotoSeguraAPI.Controllers{

    [ApiController]
    [Route("api/usuario/{userId}/historial")]
    public class HistorialController : ControllerBase
    {
        private readonly HistorialUsuarioService _historialService;

        public HistorialController(HistorialUsuarioService historialService)
        {
            _historialService = historialService;
        }

        [HttpGet]
        public ActionResult<HistorialUsuarioDto> Get(Guid userId)
        {
            try
            {
                var historial = _historialService.ObtenerHistorial(userId);
                return Ok(historial);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MotoSeguraAPI.Data;
using MotoSeguraApi.Dtos;
using MotoSeguraAPI.Models;
using AutoMapper;

namespace MotoSeguraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrayectoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public TrayectoController(ApplicationDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult RegistrarTrayecto([FromBody] TrayectoDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == dto.UserId);
            if (user == null)
                return NotFound("Usuario no encontrado.");
                
            var trayecto = _mapper.Map<Trayecto>(dto);

            _context.Trayectos.Add(trayecto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RegistrarTrayecto), new { trayecto.Id }, new
            {
                trayecto.Id,
                trayecto.FechaInicio,
                trayecto.ModoConduccion,
                trayecto.Eventos.Count,
                trayecto.VerificacionCasco.CascoDetectado
            });
        }
    }
}
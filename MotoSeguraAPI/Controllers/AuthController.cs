using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoSeguraAPI.Services.Interfaces;
using MotoSeguraAPI.Dtos;
using System.Security.Claims;

namespace MotoSeguraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        


        public AuthController(IAuthService authService )
        {
            _authService = authService;
           

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var success = await _authService.RegisterAsync(dto);
            if (!success)
                return BadRequest("El correo ya está registrado.");

            return Ok("Usuario registrado correctamente.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            if (token == null)
                return Unauthorized("Credenciales inválidas.");

            return Ok(new { token });
        }

        
    }
}
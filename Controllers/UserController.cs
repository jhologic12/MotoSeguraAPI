using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoSeguraAPI.Services.Interfaces;

namespace MotoSeguraAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("me")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public IActionResult GetProfile()
        {
            var profile = _userService.GetProfile(User);
            if (profile == null)
                return Unauthorized("Token inválido o usuario no encontrado.");

            return Ok(profile);
        }
    }
}
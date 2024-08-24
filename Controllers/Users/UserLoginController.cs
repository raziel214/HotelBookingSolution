using Aplication.Dtos.Usuarios;
using Aplication.Service.Seguridad;
using Application.Service.Users;
using Domain.Models.Users;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Users
{
    public class UserLoginController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserLoginController> _logger;

        public UserLoginController(IUserService userService, ILogger<UserLoginController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLogin userDto)
        {
            _logger.LogInformation("Intentando loguear un usuario");
            var authResponse = await _userService.LoginUserAsync(userDto);
            if (authResponse == null)
            {
                _logger.LogWarning("No se pudo loguear el usuario");
                return Unauthorized();
            }
            _logger.LogInformation("Usuario logueado exitosamente");
            return Ok(authResponse);
        }
    }
}

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

        public UserLoginController(IUserService userService)
        {
            _userService = userService;  
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLogin userDto)
        {
            var authResponse = await _userService.LoginUserAsync(userDto);
            return Ok(authResponse);
        }
    }
}

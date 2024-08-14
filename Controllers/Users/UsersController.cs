using Application.Dtos.Usuarios;
using Application.Service.Users;
using Domain.Models.Users;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.Users
{
    [Route("/api/Hotel/v1/usuarios")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return new JsonResult(users);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRolById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

       
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserCreate user)
        {
            var CreatedUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetRolById), new { id = CreatedUser.Nombre }, CreatedUser);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }          
           await _userService.UpdateUserAsync(id, user);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();

        }
    }
}

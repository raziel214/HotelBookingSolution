using Application.Dtos.Usuarios;
using Application.Service.Users;
using Domain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.Users
{
    [Route("/api/Hotel/v1/usuarios")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            _logger.LogInformation("Intentando obtener todos los usuarios");
            var users = await _userService.GetAllUsersAsync();
            if (users == null)
            {
                _logger.LogWarning("No se encontraron usuarios");
                return NotFound();
            }
            _logger.LogInformation("Usuarios obtenidos exitosamente");
            return new JsonResult(users);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRolById(int id)
        {
            _logger.LogInformation($"Intentando obtener un usuario por ID: {id}");
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"El usuario con el ID: {id} no fue encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Usuario encontrado con el ID {id} encontrado");
            return Ok(user);
        }

       
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserCreate user)
        {
            try 
            {
                _logger.LogInformation("Intentando crear un nuevo usuario con datos: {@User}", user);
                // Hashear la contraseña antes de crear el usuario
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                var CreatedUser = await _userService.CreateUserAsync(user);
                _logger.LogInformation("Usuario creado exitosamente con ID: {Nombre}", CreatedUser.Nombre);
                return CreatedAtAction(nameof(GetRolById), new { id = CreatedUser.Nombre }, CreatedUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo usuario");
                return BadRequest();
            }
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            _logger.LogInformation($"Intentando actualizar el usuario con ID: {id}");
            var userToUpdate = await _userService.GetUserByIdAsync(id);
            if (id != user.Id)
            {
                _logger.LogWarning($"El ID de usuario: {id} no coincide con el ID de usuario: {user.Id}");
                return BadRequest();
            }
            if(userToUpdate==null)
            {
                _logger.LogWarning($"El usuario con el ID {id} no fue encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Usuario encontrado con el ID {id} encontrado");
           await _userService.UpdateUserAsync(id, user);
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _logger.LogInformation($"Intentando eliminar el usuario con ID: {id}");
            var user = await _userService.GetUserByIdAsync(id);
            if (user==null)
            {
                _logger.LogWarning($"El usuario con el ID: {id} no fue encontrado");
                return NotFound();                
            }
            _logger.LogInformation($"Usuario encontrado con el ID {id} encontrado");
            await _userService.DeleteUserAsync(id);
            return NoContent();

        }
    }
}

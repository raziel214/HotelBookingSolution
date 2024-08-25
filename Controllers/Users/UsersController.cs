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
            try
            {

                _logger.LogInformation("Intentando obtener todos los usuarios");
                var users = await _userService.GetAllUsersAsync();
                _logger.LogInformation("Usuarios obtenidos exitosamente");
                return new JsonResult(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los usuarios");
                return BadRequest();
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRolById(int id)
        {
            try
            {
                _logger.LogInformation($"Intentando obtener un usuario por ID: {id}");
                var user = await _userService.GetUserByIdAsync(id);
                _logger.LogInformation($"Usuario encontrado con el ID {id} encontrado");
                return Ok(user);
            }
            catch (KeyNotFoundException ex) {
                _logger.LogWarning(ex, $"Usuario con el id {id} no fue encontrado");
                return NotFound();
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error al obtener una reserva");
                return BadRequest();
            }
            
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
            try
            {
                _logger.LogInformation($"Intentando actualizar el usuario con ID: {id}");
                var userToUpdate = await _userService.GetUserByIdAsync(id);
                _logger.LogInformation($"Usuario encontrado con el ID {id} encontrado");
                await _userService.UpdateUserAsync(id, user);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Usuario  con el ID {id} no fue encontrado");
                return NotFound();
            }
            catch (Exception ex) {
                _logger.LogError(ex,$"Error al actualizar el usuario");
                return BadRequest();
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                _logger.LogInformation($"Intentando eliminar el usuario con ID: {id}");
                var user = await _userService.GetUserByIdAsync(id);
                _logger.LogInformation($"Usuario encontrado con el ID {id} encontrado");
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"No se encontró el usuario con el id {id}");
                return NotFound();
            }
            catch (Exception e) 
            {
                _logger.LogError(e, $"Error al eliminar el registro con el id {id}");
                return BadRequest();
            }

        }
    }
}

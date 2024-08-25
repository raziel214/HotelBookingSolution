using Application.Dtos.Roles;
using Application.Service.Roles;
using Domain.Models.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers.Roles
{

    
    [Route("/api/Hotel/v1/roles")]
    [Authorize]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RolesController> _logger;

        public RolesController(IRoleService roleService, ILogger<RolesController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRoles()
        {
            try {
                _logger.LogInformation("Intentando obtener todos los roles");
                var roles = await _roleService.GetAllRolesAsync();
                _logger.LogInformation("Roles obtenidos exitosamente");
                return new JsonResult(roles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los roles");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRolById(int id)
        {
            try 
            {
                _logger.LogInformation($"Intentando obtener un rol por ID: {id}");
                var roles = await _roleService.GetRoleByIdAsync(id);
                _logger.LogInformation($"Rol encontrado con el ID {id} encontrado");
                return Ok(roles);
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Rol con el id{id} no encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener un rol");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateRol(RoleCreate rol)
        {
            try
            {
                _logger.LogInformation("Intentando crear un nuevo rol con datos: {@Rol}", rol);
                var createdRol = await _roleService.CreateRoleAsync(rol);
                _logger.LogInformation("Rol creado exitosamente con ID: {IdRol}", createdRol.IdRol);
                return CreatedAtAction(nameof(GetRolById), new { id = createdRol.IdRol }, createdRol);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo rol");
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRol(int id, Role rol)
        {
            try
            {
                _logger.LogInformation($"Intentando actualizar el rol con ID: {id}");
                var rolToUpdate = await _roleService.GetRoleByIdAsync(id);
                await _roleService.UpdateRoleAsync(id, rol);
                _logger.LogInformation($"Rol encontrado con el ID {id} encontrado");
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Rol con el id {id} no fue encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar un rol");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            try {
                _logger.LogInformation($"Intentando eliminar el rol con ID: {id}");
                await _roleService.DeleteRoleByIdAsync(id);
                _logger.LogInformation($"Rol eliminado con el ID: {id}");
                return NoContent();
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Rol con el id {id} no fue encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar un rol");
                return BadRequest();
            }
        }

    }
}


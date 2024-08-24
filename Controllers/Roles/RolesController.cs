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
            _logger.LogInformation("Intentando obtener todos los roles");
            var roles = await _roleService.GetAllRolesAsync();
            if (roles == null)
            {
                _logger.LogWarning("No se encontraron roles");
                return NotFound();
            }
            _logger.LogInformation("Roles obtenidos exitosamente");
            return new JsonResult(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRolById(int id)
        {
            _logger.LogInformation($"Intentando obtener un rol por ID: {id}");
            var roles = await _roleService.GetRoleByIdAsync(id);
            if (roles == null)
            {
                _logger.LogWarning($"El rol con el ID: {id} no fue encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Rol encontrado con el ID {id} encontrado");
            return Ok(roles);
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
            _logger.LogInformation($"Intentando actualizar el rol con ID: {id}");
            var rolToUpdate = await _roleService.GetRoleByIdAsync(id);
            if (id != rol.Id)
            {
                _logger.LogWarning($"El ID de rol: {id} no coincide con el ID de rol: {rol.Id}");
                return BadRequest();
            }
            if(rolToUpdate == null)
            {
                _logger.LogWarning($"El rol con el ID {id} no fue encontrado");
                return NotFound();
            }
            await _roleService.UpdateRoleAsync(id,rol);
            _logger.LogInformation($"Rol encontrado con el ID {id} encontrado");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            _logger.LogInformation($"Intentando eliminar el rol con ID: {id}");
            var rol = await _roleService.GetRoleByIdAsync(id);
            if (rol == null)
            {
                _logger.LogWarning($"El rol con el ID: {id} no fue encontrado");
                return NotFound();
            }

            await _roleService.DeleteRoleByIdAsync(id);
            _logger.LogInformation($"Rol eliminado con el ID: {id}");
            return NoContent();
        }

    }
}


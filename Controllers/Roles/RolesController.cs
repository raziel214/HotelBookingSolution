using Application.Dtos.Roles;
using Application.Service.Roles;
using Domain.Models.Roles;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers.Roles
{

    [ApiController]
    [Route("/api/Hotel/v1/roles")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return new JsonResult(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRolById(int id)
        {
            var roles = await _roleService.GetRoleByIdAsync(id);
            if (roles == null)
            {
                return NotFound();
            }
            return Ok(roles);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRol(RoleCreate rol)
        {
            var createdRol = await _roleService.CreateRoleAsync(rol);
            return CreatedAtAction(nameof(GetRolById), new { id = createdRol.IdRol }, createdRol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRol(int id, Role rol)
        {
            if (id != rol.Id)
            {
                return BadRequest();
            }

            await _roleService.UpdateRoleAsync(id,rol);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            await _roleService.DeleteRoleByIdAsync(id);
            return NoContent();
        }

    }
}


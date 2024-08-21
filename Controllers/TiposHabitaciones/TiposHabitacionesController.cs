using Aplication.Dtos.HabitacionesTipos;
using Aplication.Service.TiposHabitaciones;
using Domain.Models.TiposHabitaciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.TiposHabitaciones
{

    [Route("/api/Hotel/v1/tiposhabitaciones")]
    [Authorize]
    [ApiController]
    public class TiposHabitacionesController: ControllerBase
    {
        private readonly ITipoHabitacionService _tipoHabitacionService;

        public TiposHabitacionesController(ITipoHabitacionService tipoHabitacionService)
        {
            _tipoHabitacionService = tipoHabitacionService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllHabitacionTipoAsync()
        {
            var habitaciones = await _tipoHabitacionService.GetAllHabitacionTipoAsync();
            return new JsonResult(habitaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHabitacionTipoByIdAsync(int id)
        {
            var habitacion = await _tipoHabitacionService.GetHabitacionTipoByIdAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            return Ok(habitacion);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHabitacionTipoAsync(TipoHabitacionCreate habitacion)
        {
            var createdHabitacion = await _tipoHabitacionService.CreateHabitacionTipoAsync(habitacion);
            return CreatedAtAction(nameof(GetHabitacionTipoByIdAsync), new { id = createdHabitacion.IdTipoHabitacion }, createdHabitacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitacionTipoAsync(int id, TiposHabitacion habitacion)
        {
            if (id != habitacion.IdTipoHabitacion)
            {
                return BadRequest();
            }

            await _tipoHabitacionService.UpdateHabitacionTipoAsync(habitacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitacionTipoAsync(int id)
        {
            await _tipoHabitacionService.DeleteHabitacionTipoAsync(id);
            return NoContent();
        }
    }
}

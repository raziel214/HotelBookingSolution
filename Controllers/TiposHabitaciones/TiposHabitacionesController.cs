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
        public async Task<ActionResult> GetAllHabitacion()
        {
            var habitaciones = await _tipoHabitacionService.GetAllHabitacionAsync();
            return new JsonResult(habitaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHabitacionById(int id)
        {
            var habitacion = await _tipoHabitacionService.GetHabitacionByIdAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            return Ok(habitacion);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHabitacion(TipoHabitacionCreate habitacion)
        {
            var createdHabitacion = await _tipoHabitacionService.CreateHabitacionAsync(habitacion);
            return CreatedAtAction(nameof(GetHabitacionById), new { id = createdHabitacion.IdTipoHabitacion }, createdHabitacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitacion(int id, TiposHabitacion habitacion)
        {
            if (id != habitacion.IdTipoHabitacion)
            {
                return BadRequest();
            }

            await _tipoHabitacionService.UpdateHabitacionAsync(habitacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitacion(int id)
        {
            await _tipoHabitacionService.DeleteHabitacionAsync(id);
            return NoContent();
        }
    }
}

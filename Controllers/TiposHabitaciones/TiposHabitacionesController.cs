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
        private readonly ILogger<TiposHabitacionesController> _logger;

        public TiposHabitacionesController(ITipoHabitacionService tipoHabitacionService, ILogger<TiposHabitacionesController> logger)
        {
            _tipoHabitacionService = tipoHabitacionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllHabitacionTipoAsync()
        {
            try
            {
                _logger.LogInformation("Intentando obtener todos los tipos de habitaciones");
                var habitaciones = await _tipoHabitacionService.GetAllHabitacionTipoAsync();
                _logger.LogInformation("Tipos de habitaciones obtenidos exitosamente");
                return new JsonResult(habitaciones);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los tipos de habitaciones");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHabitacionTipoByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Intentando obtener un tipo de habitacion por ID: {id}");
                var habitacion = await _tipoHabitacionService.GetHabitacionTipoByIdAsync(id);
                _logger.LogInformation($"Tipo de habitacion encontrado con el ID {id} encontrado");
                return Ok(habitacion);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Tipo de habitacion con el id {id} no fue encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener un tipo de habitacion");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateHabitacionTipoAsync(TipoHabitacionCreate habitacion)
        {
            try 
            {
                _logger.LogInformation("Intentando crear un nuevo tipo de habitacion con datos: {@Habitacion}", habitacion);
                var createdHabitacion = await _tipoHabitacionService.CreateHabitacionTipoAsync(habitacion);
                _logger.LogInformation("Tipo de habitacion creado exitosamente con ID: {IdTipoHabitacion}", createdHabitacion.IdTipoHabitacion);
                return CreatedAtAction(nameof(GetHabitacionTipoByIdAsync), new { id = createdHabitacion.IdTipoHabitacion }, createdHabitacion);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo rol");
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitacionTipoAsync(int id, TiposHabitacion habitacion)
        {
            try
            {
                _logger.LogInformation($"Intentando actualizar el tipo de habitacion con ID: {id}");                
                await _tipoHabitacionService.UpdateHabitacionTipoAsync(habitacion);
                _logger.LogInformation($"Tipo de habitacion encontrado con el ID {id} encontrado");
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Tipo de habitacion con el id {id} no fue encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar un tipo de habitacion");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitacionTipoAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Intentando eliminar el tipo de habitacion con ID: {id}");
                var habitacion = await _tipoHabitacionService.GetHabitacionTipoByIdAsync(id);
                _logger.LogInformation($"Tipo de habitacion encontrado con el ID {id} encontrado");
                await _tipoHabitacionService.DeleteHabitacionTipoAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Tipo de habitacion con el id {id} no fue encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar un tipo de habitacion");
                return BadRequest();
            }
        }
    }
}

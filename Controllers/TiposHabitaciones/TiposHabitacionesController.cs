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
            _logger.LogInformation("Intentando obtener todos los tipos de habitaciones");
            var habitaciones = await _tipoHabitacionService.GetAllHabitacionTipoAsync();
            if (habitaciones == null)
            {
                _logger.LogWarning("No se encontraron tipos de habitaciones");
                return NotFound();
            }
            _logger.LogInformation("Tipos de habitaciones obtenidos exitosamente");
            return new JsonResult(habitaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHabitacionTipoByIdAsync(int id)
        {
            _logger.LogInformation($"Intentando obtener un tipo de habitacion por ID: {id}");
            var habitacion = await _tipoHabitacionService.GetHabitacionTipoByIdAsync(id);
            if (habitacion == null)
            {
                _logger.LogWarning($"El tipo de habitacion con el ID: {id} no fue encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Tipo de habitacion encontrado con el ID {id} encontrado");
            return Ok(habitacion);
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
            _logger.LogInformation($"Intentando actualizar el tipo de habitacion con ID: {id}");
            if (id != habitacion.IdTipoHabitacion)
            {
                _logger.LogWarning($"El ID de la URL {id} no coincide con el ID del tipo de habitacion {habitacion.IdTipoHabitacion}");
                return BadRequest();
            }
            _logger.LogInformation($"Tipo de habitacion encontrado con el ID {id} encontrado");
            await _tipoHabitacionService.UpdateHabitacionTipoAsync(habitacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitacionTipoAsync(int id)
        {
            _logger.LogInformation($"Intentando eliminar el tipo de habitacion con ID: {id}");
            var habitacion = await _tipoHabitacionService.GetHabitacionTipoByIdAsync(id);
            if (habitacion==null) 
            {
                _logger.LogWarning("No se encontraron tipos de habitaciones");
                return NotFound();
            }
            _logger.LogInformation($"Tipo de habitacion encontrado con el ID {id} encontrado");
            await _tipoHabitacionService.DeleteHabitacionTipoAsync(id);
            return NoContent();
        }
    }
}

using Aplication.Dtos.Habitaciones;
using Aplication.Dtos.Hoteles;
using Aplication.Service.Habitaciones;
using Domain.Models.Habitaciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers.Habitaciones
{

    [Route("/api/Hotel/v1/habitaciones")]
    [Authorize]
    [ApiController]
    public class HabitacionesController:ControllerBase
    {
       private readonly IHabitacionService _habitacionService;
        private readonly ILogger<HabitacionesController> _logger;

       public HabitacionesController(IHabitacionService habitacionService, ILogger<HabitacionesController> logger)
        {
            _habitacionService = habitacionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllHabitacionAsync()
        {
            _logger.LogInformation("Intentando obtener todas las habitaciones");
            var habitaciones = await _habitacionService.GetAllHabitacionAsync();
            _logger.LogInformation("Habitaciones obtenidas exitosamente");
            return new JsonResult(habitaciones); 
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetByHabitacionAsyncById(int id)
        {
            try 
            {
                _logger.LogInformation($"Intentando consultar una habitacion por ID: {id}");
                var habitacion = await _habitacionService.GetByIdHabitacionAsync(id);
                _logger.LogInformation($"Habitación encontrada con el ID {id} encontrada");
                return Ok(habitacion);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "KeyNotFoundException: {Message}", ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Se produjo un error al obtener la habitación con el ID {id}");
                return NotFound();
            }
        }


        [HttpPost]
        public async Task<ActionResult> CreateHabitacionAsync(HabitacionCreate habitacion)
        {
            try
            {
                _logger.LogInformation("Intentando crear una nueva habitacion con datos: {@Habitacion}", habitacion);
                var createdHabitacion = await _habitacionService.CreateHabitacionAsync(habitacion);
                _logger.LogInformation("Habitacion creada exitosamente con ID: {IdHabitacion}", createdHabitacion.IdHabitacion);
                return CreatedAtAction(nameof(GetByHabitacionAsyncById), new { id = createdHabitacion.IdHabitacion }, createdHabitacion);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Tipo de habitación no encontrada: {IdTipoHabitacion}", habitacion.IdTipoHabitacion);
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Se produjo un error al crear la habitación. {@HabitacionCreate}", habitacion);
                return StatusCode(500, new { message = "Ocurrió un error al crear la habitación."});
            }
        }





        [HttpGet("code/{code}")]
        public async Task<ActionResult> GetHabitacionByCodeAsync(int code)
        {
            try
            {
                _logger.LogInformation($"Intentando buscar una habitación: {code}");
                var habitacion = await _habitacionService.GetHabitacionByCodeAsync(code);
                _logger.LogInformation($"Habitación encontrada con el código {code}");
                return Ok(habitacion);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex,$"No se encontró la habitación con el código {code}");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Se produjo un error al obtener la habitación con el código {code}");
                return StatusCode(500, new { message = "Ocurrió un error al buscar la habitación." });
            }
        }

        [HttpGet("type/{idtype}")]
        public async Task<ActionResult> GetHabitacionByTypeAsync(int idtype)
        {
            try 
            {
                _logger.LogInformation($"Intentando consultar habitación por ID: {idtype}");
                var habitacion = await _habitacionService.GetHabitacionByTypeAsync(idtype);
                _logger.LogInformation($"Habitación encontrada con el ID {idtype} encontrada");
                return new JsonResult(habitacion);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "KeyNotFoundException: {Message}", ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Se produjo un error al obtener la habitación con el ID {idtype}");
                return StatusCode(500, new { message = "Ocurrió un error al buscar la habitación." });
            }
            
        }

        [HttpGet("price/{price}")]
        public async Task<ActionResult> GetHabitacionByPriceAsync(int price)
        {
            try 
            {
                _logger.LogInformation($"Intentando buscar una habitación con precio: {price}");
                var habitacion = await _habitacionService.GetHabitacionByPriceAsync(price);
                _logger.LogInformation($"Habitación encontrada con el precio {price}");
                return new JsonResult(habitacion);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "KeyNotFoundException: {Message}", ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Se produjo un error al obtener la habitación con el precio {price}");
                return StatusCode(500, new { message = "Ocurrió un error al buscar la habitación."});
            }
        }

        [HttpGet("status/{status}/{cantidaPersonas}")]
        public async Task<ActionResult> GetHabitacionByStatusAndCapacityAsync(int status, int cantidaPersonas)
        {
            try
            {
                _logger.LogInformation($"Obteniendo habitaciones con estado {status} y capacidad {cantidaPersonas}");

                var habitacion = await _habitacionService.GetHabitacionByStatusAndCapacityAsync(status, cantidaPersonas);

                if (habitacion == null)
                {
                    _logger.LogWarning($"No se encontraron habitaciones con estado {status} y capacidad {cantidaPersonas}");
                    return NotFound();
                }

                _logger.LogInformation($"Se encontraron {habitacion.Count()} habitaciones con estado {status} y capacidad {cantidaPersonas}");
                return new JsonResult(habitacion);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "KeyNotFoundException: {Message}", ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Se produjo un error al obtener las habitaciones con estado {status} y capacidad {cantidaPersonas}");
                return StatusCode(500, new { message = "Ocurrió un error al buscar la habitación."});
            }
        }


        [HttpGet("hotel/{hotelId}")]
        public async Task<ActionResult> GetHabitacionByHotelAsync(int hotelId)
        {
            _logger.LogInformation($"Obteniendo habitación con el ID: {hotelId}");
            var habitaciones = await _habitacionService.GetHabitacionByHotelAsync(hotelId);
            if (habitaciones == null)
            {
                _logger.LogWarning($"Nose encontraron habitaciones con el ID: {hotelId}");
                return NotFound();
            }
            _logger.LogInformation($"Obteniendo habitación con el ID: {hotelId}");
            return new JsonResult(habitaciones);
        }

        

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitacionAsync(int id, Habitacion habitacion)
        {
            _logger.LogInformation("Intentando actualizar habitación con ID {HabitacionId}", id);
            var existingHabitacion = await _habitacionService.GetByIdHabitacionAsync(id);
            if (id != habitacion.IdHabitacion)
            {
                _logger.LogWarning("El ID de la habitación no coincide con el ID de la URL");
                return BadRequest();
            }
            if (existingHabitacion == null)
            {
                _logger.LogWarning($"La Habitación con el ID {id} no fue encontrada");
                return NotFound();
            }
            _logger.LogInformation("Actualizando habitación con ID {HabitacionId}", id);
            await _habitacionService.UpdateHabitacionAsync(id, habitacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitacionByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Intentando eliminar habitacion con ID {HabitacionId}", id);

                await _habitacionService.DeleteHabitacionByIdAsync(id);

                _logger.LogInformation("Se eliminó correctamente la habitación con ID {HabitacionId}", id);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Habitacion con ID {HabitacionId} no encontrada", id);
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Se produjo un error al eliminar la habitación con ID {HabitacionId}", id);
                return StatusCode(500, new { message = "Ocurrió un error al eliminar la habitación.", detail = ex.Message });
            }
        }
    }
}

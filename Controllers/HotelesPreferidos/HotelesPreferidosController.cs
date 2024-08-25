using Aplication.Dtos.HotelesPreferidos;
using Aplication.Service.HotelesPreferidos;
using AutoMapper;
using Domain.Models.HotelesPreferidos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.HotelesPreferidos
{
    [Route("/api/Hotel/v1/hotelespreferidos")]
    [Authorize]
    [ApiController]
    public class HotelesPreferidosController: ControllerBase
    {
        private readonly IHotelesPreferidosService _hotelesPreferidosService;
        private readonly ILogger<HotelesPreferidosController> _logger;
        
        public HotelesPreferidosController(IHotelesPreferidosService hotelesPreferidosService, ILogger<HotelesPreferidosController> logger)
        {
            _hotelesPreferidosService = hotelesPreferidosService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotelesPreferidosAsync() 
        {
            try
            {
                _logger.LogInformation("Intentando obtener todos los hoteles preferidos");
                var hotelesPreferidos = await _hotelesPreferidosService.GetAllHotelesPreferidosAsync();
                _logger.LogInformation("Hoteles preferidos obtenidos exitosamente");
                return new JsonResult(hotelesPreferidos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los hoteles preferidos");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
         public async Task<IActionResult> GetHotelPreferidoById(int id) 
        {
            try 
            {
                _logger.LogInformation($"Intentando obtener un hotel preferido por ID: {id}");
                var hotelPreferido = await _hotelesPreferidosService.GetHotelPreferidoByIdAsync(id);
                _logger.LogInformation($"Hotel preferido encontrado con el ID {id} encontrado");
                return Ok(hotelPreferido);
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotel preferido no encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener un hotel preferido");
                return BadRequest();
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetHotelPreferidoByUserIdAsync(int userId) 
        {
            try 
            {
                _logger.LogInformation($"Intentando obtener un hotel preferido por ID de usuario: {userId}");
                var hotelPreferido = await _hotelesPreferidosService.GetHotelesPreferidosByUserIdAsync(userId);
                _logger.LogInformation($"Hotel preferido encontrado con el ID de usuario {userId} encontrado");
                return Ok(hotelPreferido);
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotel preferido no encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener un hotel preferido");
                return BadRequest();
            }
        }

        [HttpGet("user/{userId}/hotel/{hotelId}")]
        public async Task<IActionResult> GetHotelPreferidoByUserIdAndHotelIdAsync(int userId, int hotelId) 
        {
            try 
            {
                _logger.LogInformation($"Intentando obtener un hotel preferido por ID de usuario: {userId} y ID de hotel: {hotelId}");
                var hotelPreferido = await _hotelesPreferidosService.GetHotelPreferidoByUserIdHotelIdAsync(userId, hotelId);
                _logger.LogInformation($"Hotel preferido encontrado con el ID de usuario {userId} y ID de hotel {hotelId} encontrado");
                return Ok(hotelPreferido);
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotel preferido no encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener un hotel preferido");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotelPreferido(HotelPreferidoCreate hotelPreferidoCreate)
        {
            try 
            {
                _logger.LogInformation("Intentando crear un nuevo hotel preferido con datos: {@HotelPreferido}", hotelPreferidoCreate);
                var createdHotelPreferido = await _hotelesPreferidosService.CreateHotelPreferidoAsync(hotelPreferidoCreate);
                _logger.LogInformation("Hotel preferido creado exitosamente");
                return CreatedAtAction(nameof(GetHotelPreferidoById), new { id = createdHotelPreferido.IdPreferido }, createdHotelPreferido);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo hotel preferido");
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotelPreferidoAsync(int id, HotelPreferido hotelPreferido) 
        {
            try 
            {
                _logger.LogInformation($"Intentando actualizar el hotel preferido con ID: {id}");
                var existingHotelPreferido = await _hotelesPreferidosService.GetHotelPreferidoByIdAsync(id);
                await _hotelesPreferidosService.UpdateHotelPreferidoAsync(id, hotelPreferido);
                _logger.LogInformation($"Actualizando hotel preferido con ID {id}");
                return NoContent();
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotel preferido no encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar un hotel preferido");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelPreferidoByIdAsync(int id) 
        {
            try
            {
                _logger.LogInformation($"Intentando eliminar el hotel preferido con ID: {id}");
                var existingHotelPreferido = await _hotelesPreferidosService.GetHotelPreferidoByIdAsync(id);
                _logger.LogInformation($"Eliminando hotel preferido con ID {id}");
                await _hotelesPreferidosService.DeleteHotelPreferidoByIdAsync(id);
                return NoContent();
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotel preferido no encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar un hotel preferido");
                return BadRequest();
            }
        }
    }
}

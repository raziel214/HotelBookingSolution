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
            _logger.LogInformation("Intentando obtener todos los hoteles preferidos");
            var hotelesPreferidos = await _hotelesPreferidosService.GetAllHotelesPreferidosAsync();
            if (hotelesPreferidos == null) 
            {
                _logger.LogWarning("No se encontraron hoteles preferidos");
                return NotFound();
            }
            _logger.LogInformation("Hoteles preferidos obtenidos exitosamente");
            return new JsonResult(hotelesPreferidos);
        }

        [HttpGet("{id}")]
         public async Task<IActionResult> GetHotelPreferidoById(int id) 
        {
            _logger.LogInformation($"Intentando obtener un hotel preferido por ID: {id}");
            var hotelPreferido = await _hotelesPreferidosService.GetHotelPreferidoByIdAsync(id);
            if (hotelPreferido == null) 
            {
                _logger.LogWarning($"El hotel preferido con el ID: {id} no fue encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Hotel preferido encontrado con el ID {id} encontrado");
            return Ok(hotelPreferido);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetHotelPreferidoByUserIdAsync(int userId) 
        {
            _logger.LogInformation($"Intentando obtener un hotel preferido por ID de usuario: {userId}");
            var hotelPreferido = await _hotelesPreferidosService.GetHotelesPreferidosByUserIdAsync(userId);
            if (hotelPreferido == null) 
            {
                _logger.LogWarning($"El hotel preferido con el ID de usuario: {userId} no fue encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Hotel preferido encontrado con el ID de usuario {userId} encontrado");
            return Ok(hotelPreferido);
        }

        [HttpGet("user/{userId}/hotel/{hotelId}")]
        public async Task<IActionResult> GetHotelPreferidoByUserIdAndHotelIdAsync(int userId, int hotelId) 
        {
            _logger.LogInformation($"Intentando obtener un hotel preferido por ID de usuario: {userId} y ID de hotel: {hotelId}");
            var hotelPreferido = await _hotelesPreferidosService.GetHotelPreferidoByUserIdHotelIdAsync(userId, hotelId);
            if (hotelPreferido == null) 
            {
                _logger.LogWarning($"El hotel preferido con el ID de usuario: {userId} y ID de hotel: {hotelId} no fue encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Hotel preferido encontrado con el ID de usuario {userId} y ID de hotel {hotelId} encontrado");
            return Ok(hotelPreferido);
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
            _logger.LogInformation($"Intentando actualizar el hotel preferido con ID: {id}");
            var existingHotelPreferido = await _hotelesPreferidosService.GetHotelPreferidoByIdAsync(id);
            if (id != hotelPreferido.IdPreferido) 
            {
                _logger.LogWarning($"El ID de la URL {id} no coincide con el ID del hotel preferido {hotelPreferido.IdPreferido}");
                return BadRequest();
            }
            if (existingHotelPreferido == null) 
            {
                _logger.LogWarning($"El hotel preferido con el ID {id} no fue encontrado");
                return NotFound();
            }            
            await _hotelesPreferidosService.UpdateHotelPreferidoAsync(id, hotelPreferido);
            _logger.LogInformation($"Actualizando hotel preferido con ID {id}");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelPreferidoByIdAsync(int id) 
        {
            _logger.LogInformation($"Intentando eliminar el hotel preferido con ID: {id}");
            var existingHotelPreferido = await _hotelesPreferidosService.GetHotelPreferidoByIdAsync(id);
            if (existingHotelPreferido == null) 
            {
                _logger.LogWarning($"El hotel preferido con el ID {id} no fue encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Eliminando hotel preferido con ID {id}");
            await _hotelesPreferidosService.DeleteHotelPreferidoByIdAsync(id);
            return NoContent();
        }
    }
}

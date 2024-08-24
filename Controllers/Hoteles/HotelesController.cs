using Aplication.Dtos.Hoteles;
using Aplication.Service.Hoteles;
using Domain.Models.Hoteles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Hoteles
{
    [Route("/api/Hotel/v1/hoteles")]
    [Authorize]
    [ApiController]
    public class HotelesController: ControllerBase
    {
        private readonly IHotelService _hotelService;        
        private readonly ILogger<HotelesController> _logger;

        public HotelesController(IHotelService hotelService, ILogger<HotelesController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllHotelsAsync()
        {
            try
            {
                _logger.LogInformation("Intentando obtener todos los hoteles");
                var hoteles = await _hotelService.GetAllHotelsAsync();
                _logger.LogInformation("Hoteles obtenidos exitosamente");
                return new JsonResult(hoteles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los hoteles");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHotelById(int id)
        {
            try
            {
                _logger.LogInformation($"Intentando consultar un hotel por ID: {id}");
                var hotel = await _hotelService.GetHotelByIdAsync(id);
                _logger.LogInformation($"Hotel encontrado con el ID {id} encontrado");
                return Ok(hotel);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Hotel con el id {id} no fue encontrado");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener un hotel");
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateHotelAsync(HotelCreate hotel)
        {
            try 
            {
                _logger.LogInformation("Intentando crear un nuevo hotel con datos: {@Hotel}", hotel);
                var createdHotel = await _hotelService.CreateHotelAsync(hotel);
                return CreatedAtAction(nameof(GetHotelById), new { id = createdHotel.IdHotel }, createdHotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo hotel");
                return BadRequest();
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotelAsync(int id, Hotel hotel)
        {
            try {
                _logger.LogInformation($"Intentando actualizar el hotel con ID: {id}");
                var existingHotel = await _hotelService.GetHotelByIdAsync(id);
                _logger.LogInformation($"Actualizando hotel con ID: {id}");
                await _hotelService.UpdateHotelAsync(id, hotel);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Hotel con ID: {id} no encontrado");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el hotel con ID: {id}");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelByIdAsync(int id)
        {
            try 
            {
                _logger.LogInformation($"Intentando eliminar el hotel con ID: {id}");                
                await _hotelService.DeleteHotelByIdAsync(id);
                _logger.LogInformation($"Hotel con ID: {id} eliminado correctamente");
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Hotel con ID: {id} no encontrado");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el hotel con ID: {id}");
                return BadRequest();
            }
        }

        [HttpGet("byname/{name}")]
        public async Task<ActionResult> GetHotelByNameAsync(string name)
        {
            try {
                _logger.LogInformation($"Intentando obtener hotel por nombre: {name}");
                var hotel = await _hotelService.GetHotelByNameAsync(name);
                _logger.LogInformation($"Hotel con nombre: {name} encontrado");
                return Ok(hotel);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Hotel con nombre: {name} no encontrado");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener hotel por nombre: {name}");
                return BadRequest();
            }
        }

        [HttpGet("bycode/{code}")]
        public async Task<ActionResult> GetHotelByCodeAsync(string code)
        {
            try {
                _logger.LogInformation($"Intentando obtener hotel por código: {code}");
                var hotel = await _hotelService.GetHotelByCodeAsync(code);

                _logger.LogInformation($"Hotel con código: {code} encontrado");
                return Ok(hotel);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Hotel con código: {code} no encontrado");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener hotel por código: {code}");
                return BadRequest();
            }
        }



    }
}

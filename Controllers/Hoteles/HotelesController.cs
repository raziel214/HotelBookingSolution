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
            _logger.LogInformation("Intentando obtener todos los hoteles");
            var hoteles = await _hotelService.GetAllHotelsAsync();
            _logger.LogInformation("Hoteles obtenidos exitosamente");
            return new JsonResult(hoteles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHotelById(int id)
        {
            _logger.LogInformation($"Intentando consultar un hotel por ID: {id}");
            var hotel = await _hotelService.GetHotelByIdAsync(id);
            if (hotel == null)
            {
                _logger.LogWarning($"El hotel con el ID: {id} no fue encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Hotel encontrado con el ID {id} encontrado");
            return Ok(hotel);
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
            _logger.LogInformation($"Intentando actualizar el hotel con ID: {id}");
            if (id != hotel.IdHotel)
            {
                _logger.LogWarning($"El ID de la URL {id} no coincide con el ID del hotel {hotel.IdHotel}");
                return BadRequest();
            }
            var existingHotel = await _hotelService.GetHotelByIdAsync(id);

            if (existingHotel == null)
            {
                _logger.LogWarning($"El hotel con el ID {id} no fue encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Actualizando hotel con ID: {id}");
            await _hotelService.UpdateHotelAsync(id, hotel);
            return NoContent();
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
            _logger.LogInformation($"Intentando obtener hotel por nombre: {name}");
            var hotel = await _hotelService.GetHotelByNameAsync(name);
            if (hotel == null)
            {
                _logger.LogWarning($"Hotel con nombre: {name} no encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Hotel con nombre: {name} encontrado");
            return Ok(hotel);
        }

        [HttpGet("bycode/{code}")]
        public async Task<ActionResult> GetHotelByCodeAsync(string code)
        {
            _logger.LogInformation($"Intentando obtener hotel por código: {code}");
            var hotel = await _hotelService.GetHotelByCodeAsync(code);
            if (hotel == null)
            {
                _logger.LogWarning($"Hotel con código: {code} no encontrado");
                return NotFound();
            }
            _logger.LogInformation($"Hotel con código: {code} encontrado");
            return Ok(hotel);
        }



    }
}

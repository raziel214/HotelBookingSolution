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

        public HotelesController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllHotelsAsync()
        {
            var hoteles = await _hotelService.GetAllHotelsAsync();
            return new JsonResult(hoteles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotelByIdAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateHotelAsync(HotelCreate hotel)
        {
            var createdHotel = await _hotelService.CreateHotelAsync(hotel);
            return CreatedAtAction(nameof(GetHotelById), new { id = createdHotel.IdHotel }, createdHotel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotelAsync(int id, Hotel hotel)
        {
            if (id != hotel.IdHotel)
            {
                return BadRequest();
            }

            await _hotelService.UpdateHotelAsync(id, hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelByIdAsync(int id)
        {
            await _hotelService.DeleteHotelByIdAsync(id);
            return NoContent();
        }

        [HttpGet("byname/{name}")]
        public async Task<ActionResult> GetHotelByNameAsync(string name)
        {
            var hotel = await _hotelService.GetHotelByNameAsync(name);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpGet("bycode/{code}")]
        public async Task<ActionResult> GetHotelByCodeAsync(string code)
        {
            var hotel = await _hotelService.GetHotelByCodeAsync(code);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }



    }
}

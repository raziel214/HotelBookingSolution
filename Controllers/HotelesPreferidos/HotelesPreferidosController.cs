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
        public HotelesPreferidosController(IHotelesPreferidosService hotelesPreferidosService) 
        {
            _hotelesPreferidosService = hotelesPreferidosService;        
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHotelesPreferidosAsync() 
        {
            var hotelesPreferidos = await _hotelesPreferidosService.GetAllHotelesPreferidosAsync();
            return new JsonResult(hotelesPreferidos);
        }

        [HttpGet("{id}")]
         public async Task<IActionResult> GetHotelPreferidoById(int id) 
        {
            var hotelPreferido = await _hotelesPreferidosService.GetHotelPreferidoByIdAsync(id);
            if (hotelPreferido == null) 
            {
                return NotFound();
            }
            return Ok(hotelPreferido);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetHotelPreferidoByUserIdAsync(int userId) 
        {
            var hotelPreferido = await _hotelesPreferidosService.GetHotelesPreferidosByUserIdAsync(userId);
            if (hotelPreferido == null) 
            {
                return NotFound();
            }
            return Ok(hotelPreferido);
        }

        [HttpGet("user/{userId}/hotel/{hotelId}")]
        public async Task<IActionResult> GetHotelPreferidoByUserIdAndHotelIdAsync(int userId, int hotelId) 
        {
            var hotelPreferido = await _hotelesPreferidosService.GetHotelPreferidoByUserIdHotelIdAsync(userId, hotelId);
            if (hotelPreferido == null) 
            {
                return NotFound();
            }
            return Ok(hotelPreferido);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotelPreferido(HotelPreferidoCreate hotelPreferidoCreate)
        {
            var createdHotelPreferido=await _hotelesPreferidosService.CreateHotelPreferidoAsync(hotelPreferidoCreate);
            return CreatedAtAction(nameof(GetHotelPreferidoById), new { id = createdHotelPreferido.IdPreferido }, createdHotelPreferido);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotelPreferidoAsync(int id, HotelPreferido hotelPreferido) 
        {
            if (id != hotelPreferido.IdPreferido) 
            {
                return BadRequest();
            }
            await _hotelesPreferidosService.UpdateHotelPreferidoAsync(id, hotelPreferido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelPreferidoByIdAsync(int id) 
        {
            await _hotelesPreferidosService.DeleteHotelPreferidoByIdAsync(id);
            return NoContent();
        }



    }
}

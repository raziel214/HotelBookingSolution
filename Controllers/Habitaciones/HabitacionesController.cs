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

       public HabitacionesController(IHabitacionService habitacionService) 
       {
        _habitacionService = habitacionService;
       }

        [HttpGet]
        public async Task<ActionResult> GetAllHabitacionAsync()
        {
            var habitaciones = await _habitacionService.GetAllHabitacionAsync();
            return new JsonResult(habitaciones); 
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetByHabitacionAsyncById(int id)
        {
            var habitacion = await _habitacionService.GetByIdHabitacionAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            return Ok(habitacion);
        }


        [HttpPost]
        public async Task<ActionResult> CreateHabitacionAsync(HabitacionCreate habitacion)
        {

            try
            {
                var createdHabitacion = await _habitacionService.CreateHabitacionAsync(habitacion);
                return CreatedAtAction(nameof(GetByHabitacionAsyncById), new { id = createdHabitacion.IdHabitacion }, createdHabitacion);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al crear la habitación.", detail = ex.Message });
            }
        }




        [HttpGet("code/{code}")]
        public async Task<ActionResult> GetHabitacionByCodeAsync(int code)
        {
            var habitacion = await _habitacionService.GetHabitacionByCodeAsync(code);
            if (habitacion == null)
            {
                return NotFound();
            }
            return Ok(habitacion);
        }

        [HttpGet("type/{idtype}")]
        public async Task<ActionResult> GetHabitacionByTypeAsync(int idtype)
        {
            var habitacion = await _habitacionService.GetHabitacionByTypeAsync(idtype);
            if (habitacion == null)
            {
                return NotFound();
            }
            return new JsonResult(habitacion);
        }

        [HttpGet("price/{price}")]
        public async Task<ActionResult> GetHabitacionByPriceAsync(int price)
        {
            var habitacion = await _habitacionService.GetHabitacionByPriceAsync(price);
            if (habitacion == null)
            {
                return NotFound();
            }
            return new JsonResult(habitacion);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult> GetHabitacionByStatusAsync(int status)
        {
            var habitacion = await _habitacionService.GetHabitacionByStatusAsync(status);            
            return new JsonResult(habitacion);            
        }

        [HttpGet("hotel/{hotelId}")]
        public async Task<ActionResult> GetHabitacionByHotelAsync(int hotelId)
        {
            var habitaciones = await _habitacionService.GetHabitacionByHotelAsync(hotelId);
            if (habitaciones == null)
            {
                return NotFound();
            }
            return new JsonResult(habitaciones);
        }

        

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitacionAsync(int id, Habitacion habitacion)
        {
            if (id != habitacion.IdHabitacion)
            {
                return BadRequest();
            }

            await _habitacionService.UpdateHabitacionAsync(id, habitacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitacionByIdAsync(int id)
        {
            await _habitacionService.DeleteHabitacionByIdAsync(id);
            return NoContent();
        }



    }
    
}

﻿using Aplication.Dtos.Habitaciones;
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
        public async Task<ActionResult> GetByIdHabitacionAsync(int id)
        {
            var habitacion = await _habitacionService.GetByIdHabitacionAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            return Ok(habitacion);
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
        public async Task<ActionResult> GetHabitacionByTypeAsync(int type)
        {
            var habitacion = await _habitacionService.GetHabitacionByTypeAsync(type);
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
        public async Task<ActionResult> GetHabitacionByStatusAsync(string status)
        {
            var habitacion = await _habitacionService.GetHabitacionByStatusAsync(status);
            if (habitacion == null)
            {
                return NotFound();
            }
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

        [HttpPost]
        public async Task<ActionResult> CreateHabitacionAsync(HabitacionCreate habitacion)
        {
            var createdHabitacion = await _habitacionService.CreateHabitacionAsync(habitacion);
            return CreatedAtAction(nameof(GetByIdHabitacionAsync), new { id = createdHabitacion.IdHabitacion }, createdHabitacion);
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

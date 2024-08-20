using Aplication.Dtos.Reservas;
using Aplication.Service.Reservas;
using Domain.Models.Reservas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Reservas
{
    [Route("/api/Hotel/v1/reservas")]
    [Authorize]
    [ApiController]
    public class ReservasController: ControllerBase
    {
        private readonly IReservasService _reservaService;

        public ReservasController(IReservasService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllReservasAsync()
        {
            var reservas = await _reservaService.GetAllReservasAsync();
            return new JsonResult(reservas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetReservaById(int id)
        {
            var reserva = await _reservaService.GetReservaByIdAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReservaAsync(ReservasCreate reserva)
        {
            var createdReserva = await _reservaService.CreateReservaAsync(reserva);
            return CreatedAtAction(nameof(GetReservaById), new { id = createdReserva.IdReserva }, createdReserva);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservaAsync(int id, Reserva reserva)
        {
            if (id != reserva.IdReserva)
            {
                return BadRequest();
            }

            await _reservaService.UpdateReservaAsync(id, reserva);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservaByIdAsync(int id)
        {
            await _reservaService.DeleteReservaByIdAsync(id);
            return NoContent();
        }
    }
}

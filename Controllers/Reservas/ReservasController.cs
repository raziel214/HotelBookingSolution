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
        private readonly ILogger<ReservasController> _logger;

        public ReservasController(IReservasService reservaService, ILogger<ReservasController> logger)
        {
            _reservaService = reservaService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllReservasAsync()
        {
            _logger.LogInformation("Intentando obtener todas las reservas");
            var reservas = await _reservaService.GetAllReservasAsync();
            if (reservas == null)
            {
                _logger.LogWarning("No se encontraron reservas");
                return NotFound();
            }
            _logger.LogInformation("Reservas obtenidas exitosamente");
            return new JsonResult(reservas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetReservaById(int id)
        {
            _logger.LogInformation($"Intentando obtener una reserva por ID: {id}");
            var reserva = await _reservaService.GetReservaByIdAsync(id);
            if (reserva == null)
            {
                _logger.LogWarning($"La reserva con el ID: {id} no fue encontrada");
                return NotFound();
            }
            _logger.LogInformation($"Reserva encontrada con el ID {id} encontrada");
            return Ok(reserva);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReservaAsync(ReservasCreate reserva)
        {
            try 
            {
                _logger.LogInformation("Intentando crear una nueva reserva con datos: {@Reserva}", reserva);
                var createdReserva = await _reservaService.CreateReservaAsync(reserva);
                _logger.LogInformation("Reserva creada exitosamente con ID: {IdReserva}", createdReserva.IdReserva);
                return CreatedAtAction(nameof(GetReservaById), new { id = createdReserva.IdReserva }, createdReserva);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear una nueva reserva");
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservaAsync(int id, Reserva reserva)
        {
            _logger.LogInformation($"Intentando actualizar la reserva con ID: {id}");
            var reservaToUpdate = await _reservaService.GetReservaByIdAsync(id);
            if (id != reserva.IdReserva)
            {
                _logger.LogWarning($"El ID de la URL {id} no coincide con el ID de la reserva {reserva.IdReserva}");
                return BadRequest();
            }
            if(reservaToUpdate==null)
            {
                _logger.LogWarning($"La reserva con el ID {id} no fue encontrada");
                return NotFound();
            }
            _logger.LogInformation($"Reserva encontrada con el ID {id} encontrada");
            await _reservaService.UpdateReservaAsync(id, reserva);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservaByIdAsync(int id)
        {
            _logger.LogInformation($"Intentando eliminar la reserva con ID: {id}");
            var reserva = await _reservaService.GetReservaByIdAsync(id);
            if (reserva==null)
            {
                _logger.LogWarning($"La reserva con el ID {id} no fue encontrada");
                return NotFound();               
            }
            _logger.LogInformation($"Reserva encontrada con el ID {id} encontrada");
            await _reservaService.DeleteReservaByIdAsync(id);
            return NoContent();
        }
    }
}

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
            try
            {
                _logger.LogInformation("Intentando obtener todas las reservas");
                var reservas = await _reservaService.GetAllReservasAsync();
                _logger.LogInformation("Reservas obtenidas exitosamente");
                return new JsonResult(reservas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas las reservas");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetReservaById(int id)
        {
            try 
            {
                _logger.LogInformation($"Intentando obtener una reserva por ID: {id}");
                var reserva = await _reservaService.GetReservaByIdAsync(id);
                _logger.LogInformation($"Reserva encontrada con el ID {id} encontrada");
                return Ok(reserva);
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Reserva con el id {id} no fue encontrada");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener una reserva");
                return BadRequest();
            }
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
            try 
            {
                _logger.LogInformation($"Intentando actualizar la reserva con ID: {id}");
                var reservaToUpdate = await _reservaService.GetReservaByIdAsync(id);
                _logger.LogInformation($"Reserva encontrada con el ID {id} encontrada");
                await _reservaService.UpdateReservaAsync(id, reserva);
                return NoContent();
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Reserva con el id {id} no fue encontrada");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar una reserva");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservaByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Intentando eliminar la reserva con ID: {id}");
                await _reservaService.DeleteReservaByIdAsync(id);
                _logger.LogInformation($"Reserva encontrada con el ID {id} encontrada");
                return NoContent();
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Reserva con el id {id} no fue encontrada");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar una reserva");
                return BadRequest();
            }
        }
    }
}

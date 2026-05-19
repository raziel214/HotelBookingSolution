using MediatR;
using HotelBooking.Application.Reservas.Commands.CancelarReserva;
using HotelBooking.Application.Reservas.Commands.CreateReserva;
using HotelBooking.Application.Reservas.Commands.UpdateReserva;
using HotelBooking.Application.Reservas.Queries.GetAllReservas;
using HotelBooking.Application.Reservas.Queries.GetReservaById;

namespace HotelBooking.Api.Endpoints;

public sealed class ReservasEndpoints : IEndpointModule
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Hotel/v1/reservas").WithTags("Reservas").RequireAuthorization();

        group.MapGet("/", async (ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetAllReservasQuery(), ct)));

        group.MapGet("/{id:int}", async (int id, ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetReservaByIdQuery(id), ct)));

        group.MapPost("/", async (CreateReservaCommand command, ISender sender, CancellationToken ct) =>
        {
            var created = await sender.Send(command, ct);
            return Results.Created($"/api/Hotel/v1/reservas/{created.Id}", created);
        });

        group.MapPut("/{id:int}", async (int id, UpdateReservaCommand command, ISender sender, CancellationToken ct) =>
        {
            if (id != command.Id) return Results.BadRequest("El id de la ruta no coincide con el id del cuerpo.");
            await sender.Send(command, ct);
            return Results.NoContent();
        });

        group.MapPost("/{id:int}/cancelar", async (int id, ISender sender, CancellationToken ct) =>
        {
            await sender.Send(new CancelarReservaCommand(id), ct);
            return Results.NoContent();
        });
    }
}

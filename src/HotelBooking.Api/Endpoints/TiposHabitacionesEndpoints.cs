using MediatR;
using HotelBooking.Application.TiposHabitaciones.Commands.CreateTipoHabitacion;
using HotelBooking.Application.TiposHabitaciones.Commands.DeleteTipoHabitacion;
using HotelBooking.Application.TiposHabitaciones.Commands.UpdateTipoHabitacion;
using HotelBooking.Application.TiposHabitaciones.Queries.GetAllTiposHabitaciones;
using HotelBooking.Application.TiposHabitaciones.Queries.GetTipoHabitacionById;

namespace HotelBooking.Api.Endpoints;

public sealed class TiposHabitacionesEndpoints : IEndpointModule
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Hotel/v1/tipos-habitaciones").WithTags("TiposHabitaciones").RequireAuthorization();

        group.MapGet("/", async (ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetAllTiposHabitacionesQuery(), ct)));

        group.MapGet("/{id:int}", async (int id, ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetTipoHabitacionByIdQuery(id), ct)));

        group.MapPost("/", async (CreateTipoHabitacionCommand command, ISender sender, CancellationToken ct) =>
        {
            var created = await sender.Send(command, ct);
            return Results.Created($"/api/Hotel/v1/tipos-habitaciones/{created.Id}", created);
        });

        group.MapPut("/{id:int}", async (int id, UpdateTipoHabitacionCommand command, ISender sender, CancellationToken ct) =>
        {
            if (id != command.Id) return Results.BadRequest("El id de la ruta no coincide con el id del cuerpo.");
            await sender.Send(command, ct);
            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (int id, ISender sender, CancellationToken ct) =>
        {
            await sender.Send(new DeleteTipoHabitacionCommand(id), ct);
            return Results.NoContent();
        });
    }
}

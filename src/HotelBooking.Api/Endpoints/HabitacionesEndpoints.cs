using MediatR;
using HotelBooking.Application.Habitaciones.Commands.CreateHabitacion;
using HotelBooking.Application.Habitaciones.Commands.DeleteHabitacion;
using HotelBooking.Application.Habitaciones.Commands.UpdateHabitacion;
using HotelBooking.Application.Habitaciones.Queries.GetAllHabitaciones;
using HotelBooking.Application.Habitaciones.Queries.GetHabitacionById;
using HotelBooking.Application.Habitaciones.Queries.GetHabitacionesByEstado;
using HotelBooking.Application.Habitaciones.Queries.GetHabitacionesByHotel;
using HotelBooking.Application.Habitaciones.Queries.GetHabitacionesByTipo;

namespace HotelBooking.Api.Endpoints;

public sealed class HabitacionesEndpoints : IEndpointModule
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Hotel/v1/habitaciones").WithTags("Habitaciones").RequireAuthorization();

        group.MapGet("/", async (ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetAllHabitacionesQuery(), ct)));

        group.MapGet("/{id:int}", async (int id, ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetHabitacionByIdQuery(id), ct)));

        group.MapGet("/hotel/{idHotel:int}", async (int idHotel, ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetHabitacionesByHotelQuery(idHotel), ct)));

        group.MapGet("/tipo/{idTipo:int}", async (int idTipo, ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetHabitacionesByTipoQuery(idTipo), ct)));

        group.MapGet("/estado/{estado:int}", async (int estado, ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetHabitacionesByEstadoQuery(estado), ct)));

        group.MapPost("/", async (CreateHabitacionCommand command, ISender sender, CancellationToken ct) =>
        {
            var created = await sender.Send(command, ct);
            return Results.Created($"/api/Hotel/v1/habitaciones/{created.Id}", created);
        });

        group.MapPut("/{id:int}", async (int id, UpdateHabitacionCommand command, ISender sender, CancellationToken ct) =>
        {
            if (id != command.Id) return Results.BadRequest("El id de la ruta no coincide con el id del cuerpo.");
            await sender.Send(command, ct);
            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (int id, ISender sender, CancellationToken ct) =>
        {
            await sender.Send(new DeleteHabitacionCommand(id), ct);
            return Results.NoContent();
        });
    }
}

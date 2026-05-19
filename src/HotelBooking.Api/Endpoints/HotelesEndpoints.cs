using MediatR;
using HotelBooking.Application.Hoteles.Commands.CreateHotel;
using HotelBooking.Application.Hoteles.Commands.DeleteHotel;
using HotelBooking.Application.Hoteles.Commands.UpdateHotel;
using HotelBooking.Application.Hoteles.Queries.GetAllHoteles;
using HotelBooking.Application.Hoteles.Queries.GetHotelByCodigo;
using HotelBooking.Application.Hoteles.Queries.GetHotelById;
using HotelBooking.Application.Hoteles.Queries.GetHotelesByEstado;

namespace HotelBooking.Api.Endpoints;

public sealed class HotelesEndpoints : IEndpointModule
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Hotel/v1/hoteles").WithTags("Hoteles").RequireAuthorization();

        group.MapGet("/", async (ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetAllHotelesQuery(), ct)));

        group.MapGet("/{id:int}", async (int id, ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetHotelByIdQuery(id), ct)));

        group.MapGet("/codigo/{codigo}", async (string codigo, ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetHotelByCodigoQuery(codigo), ct)));

        group.MapGet("/estado/{estado:int}", async (short estado, ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetHotelesByEstadoQuery(estado), ct)));

        group.MapPost("/", async (CreateHotelCommand command, ISender sender, CancellationToken ct) =>
        {
            var created = await sender.Send(command, ct);
            return Results.Created($"/api/Hotel/v1/hoteles/{created.Id}", created);
        });

        group.MapPut("/{id:int}", async (int id, UpdateHotelCommand command, ISender sender, CancellationToken ct) =>
        {
            if (id != command.Id) return Results.BadRequest("El id de la ruta no coincide con el id del cuerpo.");
            await sender.Send(command, ct);
            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (int id, ISender sender, CancellationToken ct) =>
        {
            await sender.Send(new DeleteHotelCommand(id), ct);
            return Results.NoContent();
        });
    }
}

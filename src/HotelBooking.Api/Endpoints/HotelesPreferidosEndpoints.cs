using MediatR;
using HotelBooking.Application.HotelesPreferidos.Commands.AddHotelPreferido;
using HotelBooking.Application.HotelesPreferidos.Commands.RemoveHotelPreferido;
using HotelBooking.Application.HotelesPreferidos.Queries.GetAllHotelesPreferidos;
using HotelBooking.Application.HotelesPreferidos.Queries.GetHotelesPreferidosByUser;

namespace HotelBooking.Api.Endpoints;

public sealed class HotelesPreferidosEndpoints : IEndpointModule
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Hotel/v1/hoteles-preferidos").WithTags("HotelesPreferidos").RequireAuthorization();

        group.MapGet("/", async (ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetAllHotelesPreferidosQuery(), ct)));

        group.MapGet("/usuario/{idUsuario:int}", async (int idUsuario, ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetHotelesPreferidosByUserQuery(idUsuario), ct)));

        group.MapPost("/", async (AddHotelPreferidoCommand command, ISender sender, CancellationToken ct) =>
        {
            var created = await sender.Send(command, ct);
            return Results.Created($"/api/Hotel/v1/hoteles-preferidos/{created.Id}", created);
        });

        group.MapDelete("/{id:int}", async (int id, ISender sender, CancellationToken ct) =>
        {
            await sender.Send(new RemoveHotelPreferidoCommand(id), ct);
            return Results.NoContent();
        });
    }
}

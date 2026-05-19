using MediatR;
using HotelBooking.Application.Roles.Commands.CreateRole;
using HotelBooking.Application.Roles.Commands.DeleteRole;
using HotelBooking.Application.Roles.Commands.UpdateRole;
using HotelBooking.Application.Roles.Queries.GetAllRoles;
using HotelBooking.Application.Roles.Queries.GetRoleById;

namespace HotelBooking.Api.Endpoints;

public sealed class RolesEndpoints : IEndpointModule
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Hotel/v1/roles").WithTags("Roles").RequireAuthorization();

        group.MapGet("/", async (ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetAllRolesQuery(), ct)));

        group.MapGet("/{id:int}", async (int id, ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetRoleByIdQuery(id), ct)));

        group.MapPost("/", async (CreateRoleCommand command, ISender sender, CancellationToken ct) =>
        {
            var created = await sender.Send(command, ct);
            return Results.Created($"/api/Hotel/v1/roles/{created.Id}", created);
        });

        group.MapPut("/{id:int}", async (int id, UpdateRoleCommand command, ISender sender, CancellationToken ct) =>
        {
            if (id != command.Id) return Results.BadRequest("El id de la ruta no coincide con el id del cuerpo.");
            await sender.Send(command, ct);
            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (int id, ISender sender, CancellationToken ct) =>
        {
            await sender.Send(new DeleteRoleCommand(id), ct);
            return Results.NoContent();
        });
    }
}

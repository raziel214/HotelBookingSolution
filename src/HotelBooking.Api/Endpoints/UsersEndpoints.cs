using MediatR;
using Microsoft.AspNetCore.Authorization;
using HotelBooking.Application.Users.Commands.Register;
using HotelBooking.Application.Users.Queries.GetUserById;

namespace HotelBooking.Api.Endpoints;

public sealed class UsersEndpoints : IEndpointModule
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Hotel/v1/users").WithTags("Users").RequireAuthorization();

        group.MapPost("/register", async (RegisterUserCommand command, ISender sender, CancellationToken ct) =>
            {
                var created = await sender.Send(command, ct);
                return Results.Created($"/api/Hotel/v1/users/{created.Id}", created);
            })
            .AllowAnonymous();

        group.MapGet("/{id:int}", async (int id, ISender sender, CancellationToken ct) =>
            Results.Ok(await sender.Send(new GetUserByIdQuery(id), ct)));
    }
}

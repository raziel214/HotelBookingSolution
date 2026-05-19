using MediatR;
using HotelBooking.Application.Authentication.Commands.Login;

namespace HotelBooking.Api.Endpoints;

public sealed class AuthenticationEndpoints : IEndpointModule
{
    public void Map(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/Hotel/v1/auth").WithTags("Authentication");

        group.MapPost("/login", async (LoginCommand command, ISender sender, CancellationToken ct) =>
                Results.Ok(await sender.Send(command, ct)))
            .AllowAnonymous();
    }
}

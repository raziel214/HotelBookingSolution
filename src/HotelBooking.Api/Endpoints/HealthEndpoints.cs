namespace HotelBooking.Api.Endpoints;

public sealed class HealthEndpoints : IEndpointModule
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet("/health", () => Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow }))
            .WithTags("Health")
            .AllowAnonymous();
    }
}

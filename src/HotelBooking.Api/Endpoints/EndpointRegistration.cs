namespace HotelBooking.Api.Endpoints;

public static class EndpointRegistration
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        IEndpointModule[] modules =
        [
            new HealthEndpoints(),
            new AuthenticationEndpoints(),
            new UsersEndpoints(),
            new RolesEndpoints(),
            new HotelesEndpoints(),
            new HabitacionesEndpoints(),
            new TiposHabitacionesEndpoints(),
            new ReservasEndpoints(),
            new HotelesPreferidosEndpoints()
        ];

        foreach (var module in modules)
            module.Map(app);

        return app;
    }
}

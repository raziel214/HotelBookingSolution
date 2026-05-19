using MediatR;
using Microsoft.Extensions.Logging;

namespace HotelBooking.Application.Common.Behaviors;

public sealed class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var name = typeof(TRequest).Name;
        logger.LogInformation("Inicio de la operación: {RequestName}", name);
        try
        {
            var response = await next();
            logger.LogInformation("Fin de la operación: {RequestName}", name);
            return response;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error en la operación: {RequestName}", name);
            throw;
        }
    }
}

using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Application.Common.Exceptions;
using HotelBooking.Domain.Common;

namespace HotelBooking.Api.Middleware;

public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (status, problem) = exception switch
        {
            ValidationException ve => (
                StatusCodes.Status400BadRequest,
                new ProblemDetails
                {
                    Title = "Errores de validación",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = string.Join("; ", ve.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}"))
                }),
            NotFoundException nf => (
                StatusCodes.Status404NotFound,
                new ProblemDetails
                {
                    Title = "Recurso no encontrado",
                    Status = StatusCodes.Status404NotFound,
                    Detail = nf.Message
                }),
            DomainException de => (
                StatusCodes.Status400BadRequest,
                new ProblemDetails
                {
                    Title = "Regla de dominio violada",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = de.Message
                }),
            UnauthorizedAccessException ua => (
                StatusCodes.Status401Unauthorized,
                new ProblemDetails
                {
                    Title = "Acceso no autorizado",
                    Status = StatusCodes.Status401Unauthorized,
                    Detail = ua.Message
                }),
            _ => (
                StatusCodes.Status500InternalServerError,
                new ProblemDetails
                {
                    Title = "Error interno del servidor",
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = "Ocurrió un error inesperado."
                })
        };

        if (status == StatusCodes.Status500InternalServerError)
            logger.LogError(exception, "Excepción no controlada");
        else
            logger.LogWarning("Excepción manejada: {Message}", exception.Message);

        httpContext.Response.StatusCode = status;
        httpContext.Response.ContentType = "application/problem+json";
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);
        return true;
    }
}

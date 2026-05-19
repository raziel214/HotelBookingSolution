namespace HotelBooking.Application.Common.Exceptions;

public sealed class NotFoundException(string entity, object key)
    : Exception($"Entidad '{entity}' con id '{key}' no encontrada.")
{
    public string Entity { get; } = entity;
    public object Key { get; } = key;
}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using HotelBooking.Application.Common.Ports;
using HotelBooking.Domain.Users;

namespace HotelBooking.Infrastructure.Security;

public sealed class JwtTokenService(IOptions<JwtSettings> options) : ITokenService
{
    private readonly JwtSettings _settings = options.Value;

    public string GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();
        var keyBytes = Encoding.UTF8.GetBytes(_settings.Key);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(ClaimTypes.Name, user.Nombre),
            new("idRol", user.IdRol.ToString())
        };

        if (user.Rol is not null)
            claims.Add(new Claim(ClaimTypes.Role, user.Rol.Codigo));

        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes),
            Issuer = _settings.Issuer,
            Audience = _settings.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = handler.CreateToken(descriptor);
        return handler.WriteToken(token);
    }
}

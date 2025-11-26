using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MotoSeguraAPI.Dtos; 

namespace MotoSeguraAPI.Tests.Utils
{
    /// <summary>
    /// Utilidad para generar tokens JWT falsos en pruebas.
    /// </summary>
    public static class JwtTokenGenerator
    {
        /// <summary>
        /// Genera un token JWT con claims básicos de usuario.
        /// </summary>
        /// <param name="userId">Identificador único del usuario.</param>
        /// <param name="key">Clave secreta para firmar el token.</param>
        /// <param name="issuer">Issuer del token.</param>
        /// <param name="audience">Audience del token.</param>
        /// <param name="expiresMinutes">Tiempo de expiración en minutos (por defecto 60).</param>
        /// <returns>Token JWT en formato string.</returns>
        public static string GenerateToken(
            Guid userId,
            string key,
            string issuer,
            string audience,
            int expiresMinutes = 60)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, "testuser@example.com"),
                new Claim(ClaimTypes.Name, "Test User")
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
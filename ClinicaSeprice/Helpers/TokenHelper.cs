using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClinicaSepriceAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ClinicaSepriceAPI.Helpers
{
    public static class TokenHelper
    {
        public static string GenerarToken(Usuario usuario, IConfiguration configuration)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.User),
                new Claim(ClaimTypes.Email, usuario.Persona.Email),
                new Claim("Nombre", usuario.Persona.Nombre),
                new Claim("Apellido", usuario.Persona.Apellido)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

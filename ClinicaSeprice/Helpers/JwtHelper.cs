using ClinicaSepriceAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicaSepriceAPI.Helpers
{
    public static class JwtHelper
    {
        // Verificar las configuraciones JWT
        public static void ValidarConfiguracionJWT(IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration["Jwt:Subject"]) ||
                string.IsNullOrEmpty(configuration["Jwt:Key"]) ||
                string.IsNullOrEmpty(configuration["Jwt:Issuer"]) ||
                string.IsNullOrEmpty(configuration["Jwt:Audience"]))
            {
                throw new Exception("Faltan configuraciones de JWT en appsettings.json");
            }
        }

        // Crear los claims para el token JWT
        public static Claim[] CrearClaims(Usuario usuario, IConfiguration configuration)
        {
            return new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("IdUsuario", usuario.IdUsuario.ToString()),
                new Claim("User", usuario.User)
            };
        }

        // token JWT
        public static string GenerarTokenJWT(Claim[] claims, IConfiguration configuration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: signIn
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

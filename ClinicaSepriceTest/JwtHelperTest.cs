using ClinicaSepriceAPI.Helpers;
using ClinicaSepriceAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicaSepriceTest
{
    [TestFixture]
    public class JwtHelperTest
    {
        private IConfiguration configuration;

        [SetUp]
        public void Setup()
        {
            // Simular la configuración de appsettings.json para las pruebas
            var inMemorySettings = new Dictionary<string, string>
            {
                {"Jwt:Subject", "ClinicaSepriceTest"},
                {"Jwt:Key", "MuyLargaClaveDeSeguridadDe32CaracteresMinimo!"},
                {"Jwt:Issuer", "JwtIssuerTest"},
                {"Jwt:Audience", "JwtAudienceTest"}
            };

            configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
        }

        [Test]
        public void ValidarConfiguracionJWT_TodosLosParametrosPresentes_NoLanzaExcepcion()
        {
            // No debería lanzar ninguna excepción
            Assert.DoesNotThrow(() => JwtHelper.ValidarConfiguracionJWT(configuration));
        }

        [Test]
        public void ValidarConfiguracionJWT_FaltanParametros_LanzaExcepcion()
        {
            // Crear una configuración sin los parámetros JWT necesarios
            var incompleteConfig = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>())
                .Build();

            // Esperamos que se lance una excepción
            var ex = Assert.Throws<Exception>(() => JwtHelper.ValidarConfiguracionJWT(incompleteConfig));
            Assert.That(ex.Message, Is.EqualTo("Faltan configuraciones de JWT en appsettings.json"));
        }

        [Test]
        public void CrearClaims_RetornaClaimsCorrectos()
        {
            // Crear un usuario ficticio para la prueba
            var usuario = new Usuario
            {
                IdUsuario = 1,
                User = "testUser"
            };

            // Crear los claims usando el helper
            var claims = JwtHelper.CrearClaims(usuario, configuration);

            // Verificar que los claims contienen la información correcta
            Assert.That(claims, Has.Exactly(1).Matches<Claim>(c => c.Type == "IdUsuario" && c.Value == usuario.IdUsuario.ToString()));
            Assert.That(claims, Has.Exactly(1).Matches<Claim>(c => c.Type == "User" && c.Value == usuario.User));
        }

        [Test]
        public void GenerarTokenJWT_RetornaTokenValido()
        {
            // Crear los claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("IdUsuario", "1"),
                new Claim("User", "testUser")
            };

            // Generar el token usando el helper
            var token = JwtHelper.GenerarTokenJWT(claims, configuration);

            // Verificar que el token es válido y no está vacío
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);

            // Validar el token manualmente
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                ValidateLifetime = false // No necesitamos validar la expiración en la prueba
            };

            // Verificar que no lanza excepción y que es un token válido
            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

            Assert.IsNotNull(validatedToken);
            Assert.IsInstanceOf<JwtSecurityToken>(validatedToken);
        }
    }
}

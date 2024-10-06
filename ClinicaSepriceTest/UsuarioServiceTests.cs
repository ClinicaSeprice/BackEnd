using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Execeptions;
using ClinicaSepriceAPI.Interfaces;  // Asegúrate de tener acceso a la interfaz IUsuarioRepository
using ClinicaSepriceAPI.Models;
using ClinicaSepriceAPI.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace ClinicaSepriceTest
{
    [TestFixture]
    public class UsuarioServiceTests
    {
        private Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private UsuarioService _usuarioService;
        private Mock<IConfiguration> _configurationMock;

        [SetUp]
        public void Setup()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _configurationMock = new Mock<IConfiguration>();  // Crear el mock de IConfiguration

            // Simular valores de configuración JWT
            _configurationMock.Setup(config => config["Jwt:Key"]).Returns("ClaveSuperSeguraDe32Caracteres!!!");  // Al menos 32 caracteres
            _configurationMock.Setup(config => config["Jwt:Issuer"]).Returns("MiApp");
            _configurationMock.Setup(config => config["Jwt:Audience"]).Returns("MiAppUsuarios");
            _configurationMock.Setup(config => config["Jwt:Subject"]).Returns("MiAppJwtSubject"); // Simular Jwt:Subject

            // Simular comportamiento de ObtenerPorIdAsync y ObtenerTodosAsync
            _usuarioRepositoryMock.Setup(repo => repo.ObtenerPorIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => new Usuario { IdUsuario = id, User = "admin", Nombre = "Admin", Apellido = "AdminLast" });

            _usuarioRepositoryMock.Setup(repo => repo.ObtenerTodosAsync())
                .ReturnsAsync(new List<Usuario>
                {
                    new Usuario { IdUsuario = 1, Nombre = "Admin", Apellido = "AdminLast", User = "admin", Pass = PasswordHelper.HashPassword("admin") },
                    new Usuario { IdUsuario = 2, Nombre = "User1", Apellido = "UserLast1", User = "user1", Pass = PasswordHelper.HashPassword("password1") }
                });

            // Inyectar el repositorio simulado y la configuración simulada en el servicio
            _usuarioService = new UsuarioService(_usuarioRepositoryMock.Object, _configurationMock.Object);
        }

        // Prueba para registrar un nuevo usuario
        [Test]
        public async Task RegistrarUsuario_NuevoUsuario_SeAgregaCorrectamente()
        {
            var usuarioDTO = new UsuarioDTO { Nombre = "Juan", Apellido = "Perez", User = "nuevoUsuario", Pass = "12345" };

            _usuarioRepositoryMock.Setup(repo => repo.ObtenerTodosAsync())
                .ReturnsAsync(new List<Usuario>()); // Simula que no hay usuarios registrados

            await _usuarioService.RegistrarUsuarioAsync(usuarioDTO);

            _usuarioRepositoryMock.Verify(repo => repo.CrearUsuarioAsync(It.IsAny<Usuario>()), Times.Once);
            _usuarioRepositoryMock.Verify(repo => repo.GuardarCambiosAsync(), Times.Once);
        }

        // Prueba para registrar un usuario que ya existe
        [Test]
        public async Task RegistrarUsuario_UsuarioYaExiste_LanzaUsuarioNoExisteException()
        {
            var usuarioDTO = new UsuarioDTO { Nombre = "Admin", Apellido = "AdminLast", User = "admin", Pass = "admin" };

            Assert.ThrowsAsync<UsuarioNoExisteException>(async () =>
            {
                await _usuarioService.RegistrarUsuarioAsync(usuarioDTO);
            });
        }

        [Test]
        public async Task Login_UsuarioValido_DevuelveLoginResponseDTO()
        {
            var loginDTO = new LoginDTO { User = "user1", Pass = "password1" };

            var response = await _usuarioService.LoginAsync(loginDTO);

            Assert.NotNull(response);
            Assert.AreEqual("user1", response.Usuario.User);
        }

        // Prueba para login fallido (usuario no existe)
        [Test]
        public async Task Login_UsuarioInvalido_LanzaAutenticacionFallidaException()
        {
            var loginDTO = new LoginDTO { User = "nonexistent", Pass = "password" };

            Assert.ThrowsAsync<AutenticacionFallidaException>(async () =>
            {
                await _usuarioService.LoginAsync(loginDTO);
            });
        }

        // Prueba para login fallido (contraseña incorrecta)
        [Test]
        public async Task Login_ContraseñaIncorrecta_LanzaAutenticacionFallidaException()
        {
            var loginDTO = new LoginDTO { User = "user1", Pass = "wrongpassword" };

            Assert.ThrowsAsync<AutenticacionFallidaException>(async () =>
            {
                await _usuarioService.LoginAsync(loginDTO);
            });
        }

        [Test]
        public async Task ObtenerUsuarioPorId_UsuarioExiste_DevuelveUsuario()
        {
            var result = await _usuarioService.ObtenerUsuarioPorIdAsync(1);

            Assert.NotNull(result);
            Assert.AreEqual("admin", result.User);
        }

        [Test]
        public async Task ObtenerUsuarioPorId_UsuarioNoExiste_LanzaUsuarioNoEncontradoException()
        {
            _usuarioRepositoryMock.Setup(repo => repo.ObtenerPorIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Usuario)null); // Simula que el usuario no existe

            Assert.ThrowsAsync<UsuarioNoEncontradoException>(async () =>
            {
                await _usuarioService.ObtenerUsuarioPorIdAsync(999);
            });
        }

        [Test]
        public async Task ObtenerUsuarios_DevuelveListaDeUsuarios()
        {
            var usuarios = await _usuarioService.ObtenerUsuariosAsync();

            Assert.NotNull(usuarios);
            Assert.AreEqual(2, usuarios.Count());
        }
    }
}

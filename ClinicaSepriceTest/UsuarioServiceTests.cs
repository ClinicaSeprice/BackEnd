using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Execeptions;
using ClinicaSepriceAPI.Models;
using ClinicaSepriceAPI.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ClinicaSepriceTest  // Añadimos un namespace aquí
{
    [TestFixture]
    public class UsuarioServiceTests
    {
        private AppDbContext _dbContext;
        private UsuarioService _usuarioService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new AppDbContext(options);
            _usuarioService = new UsuarioService(_dbContext);

            _dbContext.Usuarios.AddRange(new List<Usuario>
            {
                new Usuario { User = "admin", Pass = "admin" },
                new Usuario { User = "user1", Pass = "password1" }
            });

            _dbContext.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
        }

        [Test]
        public void RegistrarUsuario_UsuarioYaExiste_LanzaUsuarioNoExisteException()
        {
            var usuarioDTO = new UsuarioDTO { User = "admin" };

            Assert.Throws<UsuarioNoExisteException>(() => _usuarioService.RegistrarUsuario(usuarioDTO));
        }

        [Test]
        public void RegistrarUsuario_NuevoUsuario_SeAgregaCorrectamente()
        {
            var usuarioDTO = new UsuarioDTO { Nombre = "Juan", Apellido = "Perez", User = "nuevoUsuario", Pass = "12345" };

            _usuarioService.RegistrarUsuario(usuarioDTO);

            var usuario = _dbContext.Usuarios.FirstOrDefault(u => u.User == "nuevoUsuario");
            Assert.NotNull(usuario);
            Assert.AreEqual("Juan", usuario.Nombre);
        }

        [Test]
        public void Login_UsuarioInvalido_LanzaAutenticacionFallidaException()
        {
            var loginDTO = new LoginDTO { User = "testuser", Pass = "wrongpassword" };

            Assert.Throws<AutenticacionFallidaException>(() => _usuarioService.Login(loginDTO));
        }

        [Test]
        public void Login_UsuarioValido_DevuelveUsuario()
        {
            var loginDTO = new LoginDTO { User = "admin", Pass = "admin" };

            var result = _usuarioService.Login(loginDTO);

            Assert.NotNull(result);
            Assert.AreEqual("admin", result.User);
        }

        [Test]
        public void ObtenerUsuarioPorId_UsuarioNoExiste_LanzaUsuarioNoEncontradoException()
        {
            Assert.Throws<UsuarioNoEncontradoException>(() => _usuarioService.ObtenerUsuarioPorId(999));
        }

        [Test]
        public void ObtenerUsuarioPorId_UsuarioExiste_DevuelveUsuario()
        {
            var result = _usuarioService.ObtenerUsuarioPorId(1);

            Assert.NotNull(result);
            Assert.AreEqual("admin", result.User);
        }
    }
}

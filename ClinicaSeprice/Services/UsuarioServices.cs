using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Execeptions;
using ClinicaSepriceAPI.Helpers;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using System.Threading.Tasks;

namespace ClinicaSepriceAPI.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        // Registrar un nuevo usuario
        public async Task RegistrarUsuarioAsync(UsuarioDTO usuarioDTO)
        {
            var usuarios = await _usuarioRepository.ObtenerTodosAsync();
            if (usuarios.Any(u => u.User == usuarioDTO.User))
            {
                throw new UsuarioNoExisteException();
            }

            var nuevoUsuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                User = usuarioDTO.User,
                Pass = PasswordHelper.HashPassword(usuarioDTO.Pass)
            };

            await _usuarioRepository.CrearUsuarioAsync(nuevoUsuario);
            await _usuarioRepository.GuardarCambiosAsync();
        }

        // Autenticar usuario
        public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            var usuario = (await _usuarioRepository.ObtenerTodosAsync())
                .FirstOrDefault(p => p.User == loginDTO.User);

            if (usuario == null)
            {
                throw new AutenticacionFallidaException();
            }

            if (!PasswordHelper.VerifyPassword(loginDTO.Pass, usuario.Pass))
            {
                throw new AutenticacionFallidaException();
            }

            JwtHelper.ValidarConfiguracionJWT(_configuration);

            var claims = JwtHelper.CrearClaims(usuario, _configuration);

            var tokenValue = JwtHelper.GenerarTokenJWT(claims, _configuration);

            return new LoginResponseDTO
            {
                Token = tokenValue,
                Usuario = new UsuarioDTO
                {
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    User = usuario.User
                }
            };
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
        {
            return await _usuarioRepository.ObtenerTodosAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorIdAsync(int id)
        {
            var usuario = await _usuarioRepository.ObtenerPorIdAsync(id);
            if (usuario == null)
            {
                throw new UsuarioNoEncontradoException();
            }
            return usuario;
        }
    }
}

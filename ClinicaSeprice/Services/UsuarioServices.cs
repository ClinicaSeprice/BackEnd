using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Execeptions;
using ClinicaSepriceAPI.Models;

namespace ClinicaSepriceAPI.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext dbContext;

        public UsuarioService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // registrar un nuevo usuario
        public void RegistrarUsuario(UsuarioDTO usuarioDTO)
        {
            if (dbContext.Usuarios.Any(u => u.User == usuarioDTO.User))
            {
                throw new UsuarioNoExisteException();
            }

            var nuevoUsuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                User = usuarioDTO.User,
                Pass = usuarioDTO.Pass
            };

            dbContext.Usuarios.Add(nuevoUsuario);
            dbContext.SaveChanges();
        }

        // autenticar usuario
        public Usuario Login(LoginDTO loginDTO)
        {
            var usuario = dbContext.Usuarios
                .FirstOrDefault(p => p.User == loginDTO.User && p.Pass == loginDTO.Pass);

            if (usuario == null)
            {
                throw new AutenticacionFallidaException();
            }

            return usuario;
        }

        // Obtener todos los usuarios
        public IQueryable<Usuario> ObtenerUsuarios()
        {
            return dbContext.Usuarios;
        }

        // Obtener usuario por ID
        public Usuario ObtenerUsuarioPorId(int id)
        {
            var usuario = dbContext.Usuarios.FirstOrDefault(p => p.IdUsuario == id);
            if (usuario == null)
            {
                throw new UsuarioNoEncontradoException();
            }

            return usuario;
        }
    }
}

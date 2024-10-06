using ClinicaSepriceAPI.Common;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage =MensajesDeErrorUsuarios.UsuarioObligatorio)]
        public string User { get; set; }

        [Required(ErrorMessage = MensajesDeErrorUsuarios.ContraseñaObligatoria)]
        public string Pass { get; set; }
    }
}

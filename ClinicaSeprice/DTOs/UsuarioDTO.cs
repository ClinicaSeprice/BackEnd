using ClinicaSepriceAPI.Common;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class UsuarioDTO
    {
    [Required(ErrorMessage = MensajesDeErrorUsuarios.NombreObligatorio)]
    public string Nombre { get; set; }

    [Required(ErrorMessage = MensajesDeErrorUsuarios.ApellidoObligatorio)]
    public string Apellido { get; set; }

    [Required(ErrorMessage = MensajesDeErrorUsuarios.UsuarioObligatorio)]
    [StringLength(100, ErrorMessage = MensajesDeErrorUsuarios.CaracteresUsuario)]
    public string User { get; set; }

    [Required(ErrorMessage = MensajesDeErrorUsuarios.ContraseñaObligatoria)]
    [StringLength(100, MinimumLength = 6, ErrorMessage = MensajesDeErrorUsuarios.CaracteresPass)]
    public string Pass { get; set; }

    public string Email { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime fechaCreacion { get; set; } = DateTime.Now;

    }
}

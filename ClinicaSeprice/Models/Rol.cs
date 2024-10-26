using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ClinicaSepriceAPI.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreRol { get; set; }

        public ICollection<PersonaRol> PersonaRoles { get; set; }
    }
}

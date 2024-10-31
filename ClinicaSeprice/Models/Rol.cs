using System.ComponentModel.DataAnnotations;


namespace ClinicaSepriceAPI.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreRol { get; set; }
        public DateTime FechaAlta { get; set; } 
        public DateTime? FechaBaja {  get; set; }

        public bool Baja {  get; set; }

        public ICollection<PersonaRol> PersonaRoles { get; set; }
    }
}

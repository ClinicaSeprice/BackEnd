using ClinicaSepriceAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class MedicoHorarioDTO
    {
        public int IdMedico { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        [Required]
        [Range(1000000, 99999999)]
        public int Dni { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [Required]
        [MaxLength(100)]

        public string Especialidad { get; set; }

        [Required]

        public int Legajo { get; set; }           

        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }


        public List<HorarioDisponibleDTO> HorarioDisponible { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class HorarioDisponibleDTO
    {
        [Required]
        public int IdMedico { get; set; }

        public string NombreMedico { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string HoraInicio { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public string HoraFin { get; set; }

        public bool Estado { get; set; } = false;
    }
}

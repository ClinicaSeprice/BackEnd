using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class DatosPacientesDTO
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        [Required]
        [Range(1000000, 99999999)]
        public int Dni { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaRegistro { get; set; }

        public bool Baja { get; set; }


        public DireccionDto Direccion { get; set; }
        public List<TurnoDTO> Turnos { get; set; }
        public HistoriaClinicaDTO HistoriaClinica { get; set; }
    }
}

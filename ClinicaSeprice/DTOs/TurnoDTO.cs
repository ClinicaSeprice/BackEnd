using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class TurnoDTO
    {
        [Required]
        public int IdPersona { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public int IdHorario { get; set; }

        [Required]
        [StringLength(200)]
        public string Motivo { get; set; }

        [StringLength(100)]
        public string Estado { get; set; } = "Pendiente"; 

        [StringLength(500)]
        public string Notas { get; set; }
    }
}
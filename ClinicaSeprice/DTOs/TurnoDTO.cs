using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        public decimal PrecioTurno { get; set; }

        [StringLength(100)]
        public string Estado { get; set; } = "Ingresado"; 

        [StringLength(500)]
        public string Notas { get; set; }

        [JsonIgnore]
        public List<FacturaDTO> Facturas { get; set; }
    }
}
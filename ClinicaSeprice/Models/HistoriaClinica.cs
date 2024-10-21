using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaSepriceAPI.Models
{
    public class HistoriaClinica
    {
        [Key]
        public int IdHistoria { get; set; }

        [Required]
        public int IdPersona { get; set; }

        public string Antecedentes { get; set; }

        public string Diagnosticos { get; set; }

        public string Tratamientos { get; set; }

        [Range(0, 999.99)]
        public decimal Peso { get; set; }

        [Range(0, 99.99)]
        public decimal Altura { get; set; }

        [Range(0, 99.99)]
        public decimal Imc { get; set; }

        [Required]
        public DateTime FechaApertura { get; set; }

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        [ForeignKey("IdPersona")]
        public Persona Persona { get; set; }
    }
}

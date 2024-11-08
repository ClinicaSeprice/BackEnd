using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class HistoriaClinicaDTO
    {

        [Required]
        public int IdHistoria { get; set; }

        [Required]
        public int IdPersona { get; set; }


        [Required]
       // [MaxLength(100)]
        public string Antecedentes { get; set; }

        [Required]
        //[MaxLength(100)]
        public string Diagnosticos { get; set; }

        [Required]
        public string Tratamientos { get; set; }

        [Required]
        [Range(0, 999.999)]
        public decimal Peso { get; set; }

        [Required]
        [Range(0, 999.99)]
        public decimal Altura { get; set; }
        
        [Range(0, 99.99)]
        public decimal? Imc { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaApertura { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaModificacion { get; set; }

    }
}

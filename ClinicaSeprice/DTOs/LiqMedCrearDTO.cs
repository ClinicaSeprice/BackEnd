using ClinicaSepriceAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaSepriceAPI.DTOs
{
    public class LiqMedCrearDTO
    {
        [Required]
        public int IdMedico { get; set; }
        [Required]
        public decimal Porcentaje { get; set; }
        public decimal MontoTotal { get; set; }
        [Required]
        public int IdMetodoPago { get; set; }
        public string NumeroTransaccion {   get; set; }
        //public Medico Medico { get; set; }
        //public MetodoPago MedodoPago { get; set; }  

    }
}

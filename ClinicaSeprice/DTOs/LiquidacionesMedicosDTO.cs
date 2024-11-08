using ClinicaSepriceAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaSepriceAPI.DTOs
{
    public class LiquidacionesMedicosDTO
    {
        [Required]
        public int IdMedico { get; set; }
        [Required]
        public DateTime FechaLiquidacion { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal MontoTotal { get; set; }
        [Required]
        public int IdMetodoDePago { get; set; }
        public string NumeroTransaccion { get; set; }
        public Medico Medico { get; set; }
        public MetodoPago MetodoDePago { get; set; }

    }
                                        }
}

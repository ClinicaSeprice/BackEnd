using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class PrecioTurnoDTO
    {
        public int IdPrecio {  get; set; }

        [Required]
        public decimal NuevoPrecio { get; set; }
    }
}

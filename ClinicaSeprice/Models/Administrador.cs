using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaSepriceAPI.Models
{
    public class Administrador:Usuario
    {      
        public int NroLegajo { get; set; }
       
    }
}

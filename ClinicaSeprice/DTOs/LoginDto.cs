using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class LoginDto
    {
        [Required]
        [MaxLength(100)]
        public string User { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class RegistroDto
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

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [Required]
        [MaxLength(100)]
        public string User { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }
    }
}

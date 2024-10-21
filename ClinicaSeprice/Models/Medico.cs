﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaSepriceAPI.Models
{
    public class Medico
    {
        [Key, ForeignKey("Persona")]
        public int IdPersona { get; set; }

        [Required]
        [MaxLength(100)]
        public string Especialidad { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Legajo { get; set; }

        public bool Baja { get; set; } = false;

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public Persona Persona { get; set; }
    }
}

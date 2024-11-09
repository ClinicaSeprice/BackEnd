namespace ClinicaSepriceAPI.DTOs
{
    public class FacturaDetalleDTO
    {
        // Información de la Factura
        public int IdFactura { get; set; }
        public string NumeroTransaccion { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoPaciente { get; set; }
        public DateTime FechaPago { get; set; }

        // Información del Paciente
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public int DniPaciente { get; set; }

        // Información del Turno
        public int IdTurno { get; set; }
        public DateTime FechaTurno { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
        public decimal PrecioTurno { get; set; }
        public string NotasTurno { get; set; }

        // Información del Horario del Turno
        public DateTime FechaHorario { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        // Información del Médico
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; }
        public string ApellidoMedico { get; set; }
        public string EspecialidadMedico { get; set; }

        // Información de la Obra Social y Plan de Obra Social
        public int IdObraSocial { get; set; }
        public string NombreObraSocial { get; set; }
        public int IdPlanObraSocial { get; set; }
        public string NombrePlanObraSocial { get; set; }
        public decimal Cobertura { get; set; }

        // Método de Pago
        public int IdMetodoPago { get; set; }
        public string NombreMetodoPago { get; set; }
    }

}

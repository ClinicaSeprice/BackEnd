namespace ClinicaSepriceAPI.DTOs
{
    public class FacturaDTO
    {
        public int IdTurno { get; set; }
        public int IdPlanObraSocial { get; set; }
        public int IdMetodoPago { get; set; }
        public string NumeroTransaccion { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoPaciente { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;
    }
}

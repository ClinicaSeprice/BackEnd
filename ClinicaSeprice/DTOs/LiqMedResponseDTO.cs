namespace ClinicaSepriceAPI.DTOs
{
    public class LiqMedResponseDTO
    {
        public int IdLiquidacion { get; set; }
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; }
        public DateTime FechaLiquidacion { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal MontoTotal { get; set; }
        public string MetodoDePago { get; set; }
        public int Transaccion { get; set; }
    }
}

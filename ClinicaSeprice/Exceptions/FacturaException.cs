namespace ClinicaSepriceAPI.Exceptions
{
    public class FacturaException : Exception
    {
        public static readonly string TurnoNoExiste = "El turno no existe.";
        public static readonly string PlanObraSocialNoExiste = "El plan de obra social no existe.";
        public static readonly string MetodoPagoInvalido = "El método de pago no existe o no está habilitado.";
        public static readonly string ErrorAlRegistrar = "Error al registrar la factura.";
        public FacturaException(): base(TurnoNoExiste)
        {
        }

        public FacturaException(string message) : base(message)
        {
        }

        public FacturaException(string message, Exception inner): base(message, inner)
        {
        }
    }
}

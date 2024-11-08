
namespace ClinicaSepriceAPI.Exceptions
{
    public class MetodoDePagoException : Exception
    {
        public static readonly string MetodoDePagoYaExiste = "El Metodo de pago ya existe";

        public MetodoDePagoException() : base(MetodoDePagoYaExiste)
        {
        }

        public MetodoDePagoException(string message) : base(message)
        {
        }

        public MetodoDePagoException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

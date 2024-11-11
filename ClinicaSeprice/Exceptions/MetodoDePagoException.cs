
namespace ClinicaSepriceAPI.Exceptions
{
    public class MetodoDePagoException : Exception
    {
        public object DataObject { get; }

        public static readonly string MetodoDePagoYaExiste = "El Metodo de pago ya existe";
        public static readonly string MedotoDePagoNoExiste = "El Metodo de pago no existe. Metodo consultado: ";

        public MetodoDePagoException() : base(MetodoDePagoYaExiste)
        {
        }

        public MetodoDePagoException(string message) : base(MedotoDePagoNoExiste)
        {
        }

        public MetodoDePagoException(string message, Exception inner) : base(message, inner)
        {
        }

        public MetodoDePagoException(string message, object dataObject) : base(message)
        {
            DataObject = dataObject;
        }       
    }
}

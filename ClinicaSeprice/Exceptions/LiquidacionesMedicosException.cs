namespace ClinicaSepriceAPI.Exceptions
{
    public class LiquidacionesMedicosException : Exception
    {
        public object DataObject { get; }

        public static readonly string LiquidacionesMedicosNoExiste = "La Liquidacion Medica no existe. Liquidacion buscada: ";

        public LiquidacionesMedicosException(string message) : base(message)
        {
        }

        public LiquidacionesMedicosException(string message, Exception inner) : base(message, inner)
        {
        }

        public LiquidacionesMedicosException(string message, object dataObject) : base(message)
        {
            DataObject = dataObject;
        }
        
    }
}

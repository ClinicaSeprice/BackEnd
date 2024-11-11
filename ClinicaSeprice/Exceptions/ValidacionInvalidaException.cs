namespace ClinicaSepriceAPI.Execeptions
{
    public class ValidacionInvalidaException : Exception
    {
        public object DataObject { get; }
        public ValidacionInvalidaException()
            : base("La validación falló.")
        {
        }

        public ValidacionInvalidaException(string message)
            : base(message)
        {
        }

        public ValidacionInvalidaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ValidacionInvalidaException(string message, object dataObject) : base(message)
        {
            DataObject = dataObject;
        }
       
    }
}

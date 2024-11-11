namespace ClinicaSepriceAPI.Execeptions
{
    public class ErrorInternoException : Exception
    {
        public object DataObject { get; }
        public ErrorInternoException()
         : base("Ocurrió un error interno.")
        {
        }

        public ErrorInternoException(string message)
            : base(message)
        {
        }

        public ErrorInternoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ErrorInternoException(string message, object dataObject) : base(message)
        {
            DataObject = dataObject;
        }       
    }
}

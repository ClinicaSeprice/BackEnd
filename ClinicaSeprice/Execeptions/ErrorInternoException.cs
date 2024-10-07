namespace ClinicaSepriceAPI.Execeptions
{
    public class ErrorInternoException: Exception
    {
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
    }
}

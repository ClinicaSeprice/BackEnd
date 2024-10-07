namespace ClinicaSepriceAPI.Execeptions
{
    public class ValidacionInvalidaException: Exception
    {
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
    }
}

namespace FreeflyAcademy.Domain.Exception
{
    public class FreeflyAcademyException : System.Exception
    {
        public FreeflyAcademyException(string message) : base(message)
        { }

        public FreeflyAcademyException(string message, System.Exception innerException) : base(message, innerException)
        { }
    }
}

namespace System
{
    public class PropostasException : Exception
    {
        public PropostasException()
        {
        }

        public PropostasException(string message)
            : base(message)
        {
        }

        public PropostasException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

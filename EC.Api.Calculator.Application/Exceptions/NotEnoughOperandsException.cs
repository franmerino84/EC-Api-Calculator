using System.Runtime.Serialization;

namespace EC.Api.Calculator.Application.Exceptions
{
    [Serializable]
    public class NotEnoughOperandsException : Exception
    {
        public NotEnoughOperandsException()
        {
        }

        public NotEnoughOperandsException(string? message) : base(message)
        {
        }

        public NotEnoughOperandsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotEnoughOperandsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
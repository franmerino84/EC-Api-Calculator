using System.Runtime.Serialization;

namespace EC.Api.Calculator.Domain.Exceptions
{
    [Serializable]
    public class SquareRootNotExactException : Exception
    {
        public SquareRootNotExactException()
        {
        }

        public SquareRootNotExactException(string? message) : base(message)
        {
        }

        public SquareRootNotExactException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SquareRootNotExactException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
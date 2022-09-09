using System;

namespace EntityCore5Extensions.Classes
{
    public class InvalidEntityStateException : Exception
    {
        public InvalidEntityStateException() { }

        public InvalidEntityStateException(string message) : base(message)
        {
        }

        public InvalidEntityStateException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

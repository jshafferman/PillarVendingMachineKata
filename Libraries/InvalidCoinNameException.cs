using System;

namespace Libraries
{
    public class InvalidCoinNameException : Exception
    {
        public InvalidCoinNameException()
        {

        }

        public InvalidCoinNameException(string message) : base(message)
        {

        }

        public InvalidCoinNameException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

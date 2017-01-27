using System;

namespace Libraries
{
    public class VendingMachineException : Exception
    {
        public VendingMachineException()
        {

        }

        public VendingMachineException(string message) : base(message)
        {

        }

        public VendingMachineException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

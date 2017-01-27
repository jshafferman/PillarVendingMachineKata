using System;

namespace Libraries
{
    public class InvalidCoinNameVendingMachineException : VendingMachineException
    {
        public InvalidCoinNameVendingMachineException()
        {

        }

        public InvalidCoinNameVendingMachineException(string message) : base(message)
        {

        }

        public InvalidCoinNameVendingMachineException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

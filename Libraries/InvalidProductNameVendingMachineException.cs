using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    public class InvalidProductNameVendingMachineException : VendingMachineException
    {
        public InvalidProductNameVendingMachineException()
        {

        }

        public InvalidProductNameVendingMachineException(string message) : base(message)
        {

        }

        public InvalidProductNameVendingMachineException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}

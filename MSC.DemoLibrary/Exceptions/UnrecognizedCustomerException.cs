using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.DemoLogic.Exceptions
{
    [Serializable]
    public class UnrecognizedCustomerException : Exception
    {
        public UnrecognizedCustomerException() { }

        public UnrecognizedCustomerException(string message) : base(message) { }

        public UnrecognizedCustomerException(string message, Exception inner) : base(message, inner) { }
    }
}

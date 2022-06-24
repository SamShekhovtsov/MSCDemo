using MSC.DemoLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.DemoLogic.Types
{
    public class Customer
    {
        public CustomerType Type { get; private set; }
        public int YearsOnBoard { get; private set; }

        public Customer(CustomerType type, int years)
        {
            this.Type = type;
            this.YearsOnBoard = years;
        }
    }
}

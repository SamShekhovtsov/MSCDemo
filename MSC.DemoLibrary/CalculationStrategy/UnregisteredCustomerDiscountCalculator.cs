using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.DemoLogic.CalculationStrategy
{
    public class UnregisteredCustomerDiscountCalculator
        : ICustomerTypedDiscountCalculator
    {
        public decimal Calculate(decimal amount, decimal baseDiscount)
        {
            return amount;
        }
    }
}

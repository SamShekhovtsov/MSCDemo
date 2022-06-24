using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.DemoLogic.CalculationStrategy
{
    public class ValuableCustomerDiscountCalculator : CustomerDiscountCalculatorBase, ICustomerTypedDiscountCalculator
    {
        public decimal Calculate(decimal amount, decimal baseDiscount)
        {
            decimal multiplier = 0.7m;
            return base.CalculateRegularDiscount(amount, baseDiscount, multiplier, true);
        }
    }
}

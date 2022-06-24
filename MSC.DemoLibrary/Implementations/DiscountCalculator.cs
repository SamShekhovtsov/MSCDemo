using MSC.DemoLogic.CalculationStrategy;
using MSC.DemoLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.DemoLogic.Implementations
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private ICustomerTypedDiscountCalculator _strategy;

        public decimal Calculate(decimal amount, decimal baseDiscount)
        {
            return _strategy.Calculate(amount, baseDiscount);
        }

        public void SetStrategy(ICustomerTypedDiscountCalculator strategy)
        {
            _strategy = strategy;
        }
    }
}

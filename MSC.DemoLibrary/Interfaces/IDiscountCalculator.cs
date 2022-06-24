using MSC.DemoLogic.CalculationStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.DemoLogic.Interfaces
{
    public interface IDiscountCalculator
    {
        decimal Calculate(decimal amount, decimal baseDiscount);
        void SetStrategy(ICustomerTypedDiscountCalculator strategy);
    }
}

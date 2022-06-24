using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSC.DemoLogic.Interfaces;
using MSC.DemoLogic.Types;

namespace MSC.DemoLogic.Services
{
    public static class DiscountCalculatorService
    {

        /// <summary>
        /// This function calculates discount based on CustomerType and years on
        /// board.
        /// </summary>
        /// <param name="yearlyCalculator">The particular instance of the calculator
        /// based on year</param> <param name="customerTypeCalculator">The particular
        /// instance of the calculator based on customer type</param> <param
        /// name="customer">Customer instance.</param> <param name="amount">Amount of
        /// discount.</param> <exception cref="ArgumentException"> Thrown when the
        /// incoming parameters are invalid.
        /// </exception>
        /// <returns>Calculated discount based on the incoming parameters. </returns>
        public static decimal Calculate(IYearlyDiscountCalculator yearlyCalculator, IDiscountCalculator customerTypeCalculator, Customer customer, decimal amount)
        {

            decimal discountBase = yearlyCalculator.CalculateBasedOnYear(customer.YearsOnBoard);
            decimal calculatedTotalDiscount = customerTypeCalculator.Calculate(amount, discountBase);

            return calculatedTotalDiscount;
        }
    }
}

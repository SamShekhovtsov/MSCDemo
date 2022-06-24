using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSC.DemoLogic.CalculationStrategy
{
    public class CustomerDiscountCalculatorBase
    {

        /// <summary>
        /// This function calculates final discount using base discount, amount and
        /// multiplier.
        /// </summary>
        /// <param name="baseDiscount">The base discount calculated based on
        /// year</param> <param name="multiplier">Custom, customer type based
        /// multiplier</param> <param name="amount">Amount of discount.</param> <param
        /// name="isValuable">Boolean flag that signalises whether it is valuable
        /// customer.</param> <exception cref="ArgumentException"> Thrown when the
        /// incoming parameters are invalid.
        /// </exception>
        /// <returns>Calculated discount based on the incoming parameters.</returns>
        protected decimal CalculateRegularDiscount(decimal amount, decimal baseDiscount, decimal multiplier, bool isValuable)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Discount amount should be greater than zero.");
            }

            decimal discountedAmount = multiplier * amount;
            if (isValuable)
            {
                return discountedAmount - baseDiscount * discountedAmount;
            }

            return (amount - discountedAmount) - baseDiscount * (amount - discountedAmount);
        }
    }
}

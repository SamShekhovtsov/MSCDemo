using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSC.DemoLogic.Interfaces;

namespace MSC.DemoLogic.Implementations
{
    public class YearlyDiscountCalculator : IYearlyDiscountCalculator
    {

        /// <summary>
        /// This function calculates discount based on the amount of years that user
        /// worked on board.
        /// </summary>
        /// <param name="yearsOnBoard">Amount of years on board.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the incoming parameters are invalid.
        /// </exception>
        /// <returns>Calculated discount based on the amount of years.</returns>
        public decimal CalculateBasedOnYear(int yearsOnBoard)
        {
            if (yearsOnBoard <= 0)
            {
                throw new ArgumentException("Years on board should be greater than zero.");
            }

            int greatestYearOnBoard = 5;
            decimal discount = (yearsOnBoard > greatestYearOnBoard)
                                   ? (decimal)greatestYearOnBoard / 100
                                   : (decimal)yearsOnBoard / 100;
            return discount;
        }
    }
}

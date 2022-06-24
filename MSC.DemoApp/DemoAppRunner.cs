using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MSC.DemoLogic.CalculationStrategy;
using MSC.DemoLogic.Interfaces;
using MSC.DemoLogic.Implementations;
using MSC.DemoLogic.Types;
using MSC.DemoLogic.Enums;
using MSC.DemoLogic.Exceptions;
using MSC.DemoLogic.Services;

namespace MSC.DemoApp
{
    internal class DemoAppRunner
    {
        internal void DoDemoDiscountCalculation()
        {
            IServiceScope scope = ConfigureDependencyInjection();

            Customer customer = new Customer(CustomerType.Registered, 6);

            ICustomerTypedDiscountCalculator calculatorStrategy;

            switch (customer.Type)
            {
                case CustomerType.Unregistered:
                    calculatorStrategy = new UnregisteredCustomerDiscountCalculator();
                    break;
                case CustomerType.Registered:
                    calculatorStrategy = new RegisteredCustomerDiscountCalculator();
                    break;
                case CustomerType.Valuable:
                    calculatorStrategy = new ValuableCustomerDiscountCalculator();
                    break;
                case CustomerType.MostValuable:
                    calculatorStrategy = new MostValuableCustomerDiscountCalculator();
                    break;
                default:
                    throw new UnrecognizedCustomerException($"Customer tpye {Enum.GetName(typeof(CustomerType), customer.Type)}");
                    break;
            }

            IYearlyDiscountCalculator yearlyCalculator = scope.ServiceProvider.GetService<IYearlyDiscountCalculator>();
            IDiscountCalculator customerTypeCalculator = scope.ServiceProvider.GetService<IDiscountCalculator>();
            customerTypeCalculator.SetStrategy(calculatorStrategy);

            decimal amount = 47;
            var discount = DiscountCalculatorService.Calculate(yearlyCalculator, customerTypeCalculator, customer, amount);
            Console.WriteLine($"Discount is calculated for customer: {discount}");
        }

        internal static IServiceScope ConfigureDependencyInjection()
        {
            var services = new ServiceCollection();

            services.AddScoped<IYearlyDiscountCalculator, YearlyDiscountCalculator>();
            services.AddScoped<IDiscountCalculator, DiscountCalculator>();

            var container = services.BuildServiceProvider(true);

            return container.CreateScope();
        }
    }
}

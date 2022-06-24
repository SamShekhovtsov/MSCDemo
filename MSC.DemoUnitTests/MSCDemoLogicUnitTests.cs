
namespace MSC.DemoUnitTests
{
    [TestClass]
    public class MSCDemoLogicUnitTests
    {
        [TestMethod]
        public void CustomerTypeDiscountClaculationTest()
        {
            // this test verifies that the discount calculator works as expected

            var yearsOnBoard = 3;
            Customer customer = new Customer(CustomerType.Registered, yearsOnBoard);

            var yearlyDiscountCalculatorMock = new Mock<IYearlyDiscountCalculator>();

            decimal calculatedDiscountBasedOnYear = 0.5m;
            yearlyDiscountCalculatorMock.Setup(x => x.CalculateBasedOnYear(It.IsAny<int>())).Returns(calculatedDiscountBasedOnYear);

            var calculatorStrategy = new RegisteredCustomerDiscountCalculator();

            var customerTypedDiscountCalculator = new DiscountCalculator();
            customerTypedDiscountCalculator.SetStrategy(calculatorStrategy);

            var amount = 47;
            var discount = DiscountCalculatorService.Calculate(yearlyDiscountCalculatorMock.Object, customerTypedDiscountCalculator, customer, amount);

            Assert.AreEqual(21.15m, discount);
        }

        [DataTestMethod]
        [DataRow(4, 0.04)]
        [DataRow(5, 0.05)]
        [DataRow(6, 0.05)]

        public void YearlyDiscountCalculatorTest(int yearsOnBoard, double discountBaseExpected)
        {
            // this test verifies that the yearly only discount calculator works as expected

            Customer customer = new Customer(CustomerType.Registered, yearsOnBoard);

            IYearlyDiscountCalculator yearlyDiscountCalculator = new YearlyDiscountCalculator();

            decimal calculatedBasedOnYear = yearlyDiscountCalculator.CalculateBasedOnYear(customer.YearsOnBoard);

            Assert.AreEqual((decimal)discountBaseExpected, calculatedBasedOnYear);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void YearlyDiscountCalculatorNegativeTest()
        {
            // this test verifies that the correct exception is thrown in case if year is not specified correctly

            var incorrectYearsOnBoard = -3;
            Customer customer = new Customer(CustomerType.Registered, incorrectYearsOnBoard);

            IYearlyDiscountCalculator yearlyDiscountCalculator = new YearlyDiscountCalculator();

            decimal calculatedBasedOnYear = yearlyDiscountCalculator.CalculateBasedOnYear(customer.YearsOnBoard);
        }

        [TestMethod]
        public void CustomerDiscountCalculatorBaseNegativeTest()
        {
            // this test verifies that the correct exception is thrown in case if amount is not specified correctly

            ICustomerTypedDiscountCalculator customerTypedDiscountCalculator = new RegisteredCustomerDiscountCalculator();

            decimal amount = -1m;
            decimal baseDiscount = 0.34m;
            Assert.ThrowsException<ArgumentException>(() => customerTypedDiscountCalculator.Calculate(amount, baseDiscount));
        }

        [DataTestMethod]
        [DynamicData(nameof(CustomnerTypeDiscountData), DynamicDataSourceType.Method)]
        public void DifferentCustomerTypesDiscountCalculationTest(int yearsOnBoard, double amount, CustomerType customerType, double discountBaseExpected)
        {
            // this test verifies that the custoemr typed discount calculator works as expected

            Customer customer = new Customer(customerType, yearsOnBoard);

            var yearlyDiscountCalculatorMock = new Mock<IYearlyDiscountCalculator>();

            decimal calculatedDiscountBasedOnYear = 0.5m;
            yearlyDiscountCalculatorMock.Setup(x => x.CalculateBasedOnYear(It.IsAny<int>())).Returns(calculatedDiscountBasedOnYear);

            var calculatorStrategy = new RegisteredCustomerDiscountCalculator();

            var customerTypedDiscountCalculator = new DiscountCalculator();
            customerTypedDiscountCalculator.SetStrategy(calculatorStrategy);

            var actualCalculatedDiscount = DiscountCalculatorService.Calculate(yearlyDiscountCalculatorMock.Object, customerTypedDiscountCalculator, customer, (decimal)amount);

            Assert.AreEqual((decimal)discountBaseExpected, actualCalculatedDiscount);
        }

        private static IEnumerable<object[]> CustomnerTypeDiscountData()
        {
            return new[]
            {
                new object[] { 1, 15, CustomerType.Unregistered, 6.75 },
                new object[] { 4, 33, CustomerType.Registered, 14.85 },
                new object[] { 5, 47, CustomerType.Valuable, 21.15 },
                new object[] { 6, 58, CustomerType.MostValuable, 26.10 }
            };
        }
    }
}
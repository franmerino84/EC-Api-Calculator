using EC.Api.Calculator.Domain.Services.CalculationFormatters.Divisions;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.Services.CalculationFormatters.Divisions
{
    [TestFixture]
    [Category(Category.Unit)]
    public class DivisionCalculationFormatterTests
    {
        [TestCase("4 / 2 = 2 % 0", 4, 2)]
        [TestCase("5 / 2 = 2 % 1", 5, 2)]
        public void FormatOperation_Expected_Formatting(string expected, int dividend, int divisor)
        {
            var result = new DivisionCalculationFormatter().FormatOperation(new Division(dividend, divisor));

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

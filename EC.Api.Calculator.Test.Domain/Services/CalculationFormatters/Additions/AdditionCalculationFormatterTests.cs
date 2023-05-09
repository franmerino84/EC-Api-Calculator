using EC.Api.Calculator.Domain.Services.CalculationFormatters.Additions;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.Services.CalculationFormatters.Additions
{
    [TestFixture]
    [Category(Category.Unit)]
    public class AdditionCalculationFormatterTests
    {
        [TestCase("1 + 1 = 2", 1, 1)]
        [TestCase("1 + 2 + 3 + 4 = 10", 1, 2, 3, 4)]
        public void FormatOperation_Expected_Formatting(string expected, params int[] addends)
        {
            var result = new AdditionCalculationFormatter().FormatCalculation(new Addition(addends));

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

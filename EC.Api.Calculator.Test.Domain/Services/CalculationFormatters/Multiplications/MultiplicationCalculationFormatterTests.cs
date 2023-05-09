using EC.Api.Calculator.Domain.Services.OperationFormatters;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.Services.CalculationFormatters.Multiplications
{
    [TestFixture]
    [Category(Category.Unit)]
    public class MultiplicationCalculationFormatterTests
    {
        [TestCase("2 * 3 = 6", 2, 3)]
        [TestCase("1 * 2 * 3 * 4 = 24", 1, 2, 3, 4)]
        public void FormatOperation_Expected_Formatting(string expected, params int[] factors)
        {
            var result = new MultiplicationCalculationFormatter().FormatOperation(new Multiplication(factors));

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

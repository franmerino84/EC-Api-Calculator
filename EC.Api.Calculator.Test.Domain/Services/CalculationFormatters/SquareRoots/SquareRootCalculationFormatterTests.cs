using EC.Api.Calculator.Domain.Services.OperationFormatters;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.Services.CalculationFormatters.SquareRoots
{
    [TestFixture]
    [Category(Category.Unit)]
    public class SquareRootCalculationFormatterTests
    {
        [TestCase("Sqrt 4 = 2", 4)]
        [TestCase("Sqrt 9 = 3", 9)]
        public void FormatOperation_Expected_Formatting(string expected, int number)
        {
            var result = new SquareRootCalculationFormatter().FormatOperation(new SquareRoot(number));

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

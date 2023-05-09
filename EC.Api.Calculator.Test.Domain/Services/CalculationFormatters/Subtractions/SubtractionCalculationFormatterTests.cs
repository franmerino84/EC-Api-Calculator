using EC.Api.Calculator.Domain.Services.CalculationFormatters.Divisions;
using EC.Api.Calculator.Domain.Services.OperationFormatters;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.Services.CalculationFormatters.Subtractions
{
    [TestFixture]
    [Category(Category.Unit)]
    public class SubtractionCalculationFormatterTests
    {
        [TestCase("4 - 2 = 2", 4, 2)]
        [TestCase("5 - 2 = 3", 5, 2)]
        public void FormatOperation_Expected_Formatting(string expected, int minuend, int subtrahend)
        {
            var result = new SubtractionCalculationFormatter().FormatCalculation(new Subtraction(minuend, subtrahend));

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

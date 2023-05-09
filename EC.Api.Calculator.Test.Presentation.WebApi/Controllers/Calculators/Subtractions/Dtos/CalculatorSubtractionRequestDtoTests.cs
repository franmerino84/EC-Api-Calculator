using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Subtractions.Dtos;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Presentation.WebApi.Controllers.Calculators.Subtractions.Dtos
{
    [TestFixture]
    [Category(Category.Unit)]
    public class CalculatorSubtractionRequestDtoTests
    {
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(105, 10)]
        public void Ctor_Minuend_Is_Copied_To_Property(int minuend, int subtrahend)
        {
            var subtraction = new CalculatorSubtractionRequestDto(minuend, subtrahend);

            Assert.That(subtraction.Minuend, Is.EqualTo(minuend));
        }

        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(105, 10)]
        public void Ctor_Subtrahend_Is_Copied_To_Property(int minuend, int subtrahend)
        {
            var subtraction = new CalculatorSubtractionRequestDto(minuend, subtrahend);

            Assert.That(subtraction.Subtrahend, Is.EqualTo(subtrahend));
        }
    }
}

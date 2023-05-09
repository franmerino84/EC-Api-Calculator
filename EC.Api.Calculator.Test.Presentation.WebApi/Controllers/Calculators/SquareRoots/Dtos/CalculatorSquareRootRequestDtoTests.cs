using EC.Api.Calculator.Infrastructure.Validation;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.SquareRoots.Dtos;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Presentation.WebApi.Controllers.Calculators.SquareRoots.Dtos
{
    [TestFixture]
    [Category(Category.Unit)]
    public class CalculatorSquareRootRequestDtoTests
    {
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(105)]
        public void Ctor_Number_Is_Copied_To_Property(int number)
        {
            var squareRoot = new CalculatorSquareRootRequestDto(number);

            Assert.That(squareRoot.Number, Is.EqualTo(number));
        }

    }
}

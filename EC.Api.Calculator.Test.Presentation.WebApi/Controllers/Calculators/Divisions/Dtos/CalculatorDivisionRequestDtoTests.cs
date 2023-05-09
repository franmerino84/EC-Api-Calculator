using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Infrastructure.Validation;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Additions.Dtos;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Divisions.Dtos;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Presentation.WebApi.Controllers.Calculators.Divisions.Dtos
{
    [TestFixture]
    [Category(Category.Unit)]
    public class CalculatorDivisionRequestDtoTests
    {
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(105, 10)]
        public void Ctor_Dividend_Is_Copied_To_Property(int dividend, int divisor)
        {
            var division = new CalculatorDivisionRequestDto(dividend, divisor);

            Assert.That(division.Dividend, Is.EqualTo(dividend));
        }

        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(105, 10)]
        public void Ctor_Divisor_Is_Copied_To_Property(int dividend, int divisor)
        {
            var division = new CalculatorDivisionRequestDto(dividend, divisor);

            Assert.That(division.Divisor, Is.EqualTo(divisor));
        }

        [Test]
        public void Validate_Divisor_Zero_IsNotValid()
        {
            var dto = new CalculatorDivisionRequestDto(5,0);

            Assert.That(dto.IsNotValid());
        }

    }
}

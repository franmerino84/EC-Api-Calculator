using EC.Api.Calculator.Infrastructure.Validation;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Multiplications.Dtos;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Presentation.WebApi.Controllers.Calculators.Multiplications.Dtos
{
    [TestFixture]
    [Category(Category.Unit)]
    public class CalculatorMultiplicationRequestDtoTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 3)]
        [TestCase(1, 2, 3, 4)]
        [TestCase(1, -1)]
        public void Ctor_Factors_Are_Copied_To_Property(params int[] factors)
        {
            var dto = new CalculatorMultiplicationRequestDto(factors.ToList());

            Assert.That(dto.Factors, Is.EquivalentTo(factors));
        }

        [Test]
        public void Validate_Less_Than_Two_Factors_IsNotValid()
        {
            var dto = new CalculatorMultiplicationRequestDto(new List<int> { 1 });

            Assert.That(dto.IsNotValid());
        }

    }
}

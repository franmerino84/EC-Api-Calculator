using EC.Api.Calculator.Infrastructure.Validation;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Additions.Dtos;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Presentation.WebApi.Controllers.Calculators.Additions.Dtos
{
    [TestFixture]
    [Category(Category.Unit)]
    public class CalculatorAdditionRequestDtoTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 3)]
        [TestCase(1, 2, 3, 4)]
        [TestCase(1, -1)]
        public void Ctor_Addends_Are_Copied_To_Property(params int[] addends)
        {
            var dto = new CalculatorAdditionRequestDto(addends.ToList());

            Assert.That(dto.Addends, Is.EquivalentTo(addends));
        }

        [Test]
        public void Validate_Less_Than_Two_Addends_IsNotValid()
        {
            var dto = new CalculatorAdditionRequestDto(new List<int> { 1 });

            Assert.That(dto.IsNotValid());
        }

    }
}

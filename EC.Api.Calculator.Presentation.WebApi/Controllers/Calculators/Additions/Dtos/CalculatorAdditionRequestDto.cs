using EC.Api.Calculator.Infrastructure.Validation.Validators;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Additions.Dtos
{
    public class CalculatorAdditionRequestDto
    {
        public CalculatorAdditionRequestDto(List<int> addends)
        {
            Addends = addends;
        }

        [EnsureMinimumElements(2, ErrorMessage = $"{nameof(Addends)} must contain at least two numbers")]
        public List<int> Addends { get; }
    }
}

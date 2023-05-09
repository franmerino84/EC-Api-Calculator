using EC.Api.Calculator.Infrastructure.Validation.Validators;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Multiplications.Dtos
{
    public class CalculatorMultiplicationRequestDto
    {
        public CalculatorMultiplicationRequestDto(List<int> factors)
        {
            Factors = factors;
        }

        [EnsureMinimumElements(2, ErrorMessage = $"{nameof(Factors)} must contain at least two numbers")]
        public List<int> Factors { get; }
    }
}

using EC.Api.Calculator.Infrastructure.Validation.Validators;
using System.ComponentModel.DataAnnotations;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Divisions
{
    public class CalculatorDivisionRequestDto
    {
        public CalculatorDivisionRequestDto(int dividend, int divisor)
        {
            Dividend = dividend;
            Divisor = divisor;
        }

        public int Dividend { get; }

        [NotZero(ErrorMessage = "Divisor cannot be zero")]
        public int Divisor { get; }
    }
}

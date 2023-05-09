namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Divisions.Dtos
{
    public class CalculatorDivisionResponseDto
    {
        public CalculatorDivisionResponseDto(int quotient, int remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }

        public int Quotient { get; }
        public int Remainder { get; }
    }
}
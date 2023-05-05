namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Subtractions
{
    public class CalculatorSubtractionResponseDto
    {
        public CalculatorSubtractionResponseDto(int difference)
        {
            Difference = difference;
        }

        public int Difference { get; }
    }
}
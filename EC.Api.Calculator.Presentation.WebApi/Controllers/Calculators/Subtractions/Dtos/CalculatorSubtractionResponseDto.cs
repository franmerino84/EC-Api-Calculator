namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Subtractions.Dtos
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
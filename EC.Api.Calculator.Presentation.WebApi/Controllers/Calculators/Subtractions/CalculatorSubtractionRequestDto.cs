namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Subtractions
{
    public class CalculatorSubtractionRequestDto
    {
        public CalculatorSubtractionRequestDto(int minuend, int subtrahend)
        {
            Minuend = minuend;
            Subtrahend = subtrahend;
        }

        public int Minuend { get; }

        public int Subtrahend { get; }
    }
}

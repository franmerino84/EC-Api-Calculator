namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.SquareRoots
{
    public class CalculatorSquareRootResponseDto
    {
        public CalculatorSquareRootResponseDto(int square)
        {
            Square = square;
        }

        public int Square { get; }
    }
}
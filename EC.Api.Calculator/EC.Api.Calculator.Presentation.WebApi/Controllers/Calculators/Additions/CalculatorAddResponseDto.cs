namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators
{
    public class CalculatorAddResponseDto
    {
        public CalculatorAddResponseDto(int sum)
        {
            Sum = sum;
        }

        public int Sum { get; }
    }
}
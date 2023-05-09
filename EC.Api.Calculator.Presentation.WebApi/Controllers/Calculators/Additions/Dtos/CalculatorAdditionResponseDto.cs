namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Additions.Dtos
{
    public class CalculatorAdditionResponseDto
    {
        public CalculatorAdditionResponseDto(int sum)
        {
            Sum = sum;
        }

        public int Sum { get; }
    }
}
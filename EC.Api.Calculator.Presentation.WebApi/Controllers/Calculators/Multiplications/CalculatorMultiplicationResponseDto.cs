namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Multiplications
{
    public class CalculatorMultiplicationResponseDto
    {
        public CalculatorMultiplicationResponseDto(int product)
        {
            Product = product;
        }

        public int Product { get; }
    }
}

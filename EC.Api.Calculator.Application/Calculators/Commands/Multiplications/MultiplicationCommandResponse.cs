namespace EC.Api.Calculator.Application.Calculators.Commands.Multiplications
{
    public class MultiplicationCommandResponse
    {
        public MultiplicationCommandResponse(int product)
        {
            Product = product;
        }

        public int Product { get; }
    }
}

namespace EC.Api.Calculator.Application.Calculators.Additions
{
    public class AdditionCommandResponse
    {
        public AdditionCommandResponse(int sum)
        {
            Sum = sum;
        }

        public int Sum { get; }
    }
}

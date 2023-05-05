namespace EC.Api.Calculator.Application.Calculators.SquareRoots
{
    public class SquareRootCommandResponse
    {
        public SquareRootCommandResponse(int square)
        {
            Square = square;
        }

        public int Square { get; }
    }
}

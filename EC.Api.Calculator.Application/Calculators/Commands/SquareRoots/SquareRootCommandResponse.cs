namespace EC.Api.Calculator.Application.Calculators.Commands.SquareRoots
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

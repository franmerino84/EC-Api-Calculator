namespace EC.Api.Calculator.Application.Calculators.Commands.Subtractions
{
    public class SubtractionCommandResponse
    {
        public SubtractionCommandResponse(int difference)
        {
            Difference = difference;
        }

        public int Difference { get; }
    }
}

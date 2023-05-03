namespace EC.Api.Calculator.Application.Calculators.Divisions
{
    public class DivisionCommandResponse
    {
        public DivisionCommandResponse(int quotient, int remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }

        public int Quotient { get; }
        public int Remainder { get; }
    }
}

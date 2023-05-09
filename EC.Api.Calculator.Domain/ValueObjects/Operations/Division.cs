namespace EC.Api.Calculator.Domain.ValueObjects.Operations
{
    public class Division : Operation
    {
        private int _quotient;
        private int _remainder;

        public Division(int dividend, int divisor)
        {
            if (divisor == 0)
                throw new ArgumentException("Divisor cannot be zero", nameof(divisor));

            Dividend = dividend;
            Divisor = divisor;
            Operate();
        }

        public int Dividend { get; }
        public int Divisor { get; }
        public int Quotient => _quotient;
        public int Remainder => _remainder;

        protected override IEnumerable<object> GetEqualityComponents() =>
            new object[] { Dividend, Divisor };

        private void Operate()
        {
            _quotient = Dividend / Divisor;
            _remainder = Dividend % Divisor;
        }
    }
}

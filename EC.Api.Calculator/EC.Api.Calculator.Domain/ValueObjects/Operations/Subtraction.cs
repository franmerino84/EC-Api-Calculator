namespace EC.Api.Calculator.Domain.ValueObjects.Operations
{
    public class Subtraction : Operation
    {
        private int _difference;

        public Subtraction(int minuend, int subtrahend)
        {
            Minuend = minuend;
            Subtrahend = subtrahend;
            Operate();
        }

        public int Difference => _difference;
        public int Minuend { get; }
        public int Subtrahend { get; }
        protected override IEnumerable<object> GetEqualityComponents() =>
            new object[] { Minuend, Subtrahend };

        private void Operate() =>
            _difference = Minuend - Subtrahend;
    }
}
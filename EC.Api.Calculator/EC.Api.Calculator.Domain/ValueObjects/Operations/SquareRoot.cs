namespace EC.Api.Calculator.Domain.ValueObjects.Operations
{
    public class SquareRoot : Operation
    {
        private int _square;

        public SquareRoot(int number)
        {
            Number = number;
            Operate(number);
        }

        public int Square => _square;
        public int Number { get; }
        protected override IEnumerable<object> GetEqualityComponents() =>
            new object[] { Number };

        private void Operate(int number)
        {
            var exactSqrt = Math.Sqrt(number);
            var floorSqrt = (int)Math.Floor(exactSqrt);

            if (floorSqrt != exactSqrt)
                throw new ArgumentException("Cannot apply square root to parameter", nameof(number));

            _square = floorSqrt;
        }
    }
}

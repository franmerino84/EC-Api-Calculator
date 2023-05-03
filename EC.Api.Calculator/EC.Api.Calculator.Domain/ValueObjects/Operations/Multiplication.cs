namespace EC.Api.Calculator.Domain.ValueObjects.Operations
{
    public class Multiplication : Operation
    {
        private int _product;

        public Multiplication(IEnumerable<int> factors)
        {
            Factors = factors ?? throw new ArgumentNullException(nameof(factors));
            Operate();
        }

        public IEnumerable<int> Factors { get; }

        public int Product => _product;

        protected override IEnumerable<object> GetEqualityComponents() =>
            Factors.Select(x => (object)x);

        private void Operate() =>
            _product = Factors.Aggregate((x, y) => x * y);
    }
}
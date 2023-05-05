namespace EC.Api.Calculator.Domain.ValueObjects.Operations
{
    public class Addition : Operation
    {
        private int _sum;

        public Addition(IEnumerable<int> addends)
        {
            Addends = addends ?? throw new ArgumentNullException(nameof(addends));
            Operate();
        }

        public IEnumerable<int> Addends { get; }

        public int Sum => _sum;

        protected override IEnumerable<object> GetEqualityComponents() =>
            Addends.Select(x => (object)x);

        private void Operate() =>
            _sum = Addends.Sum();
    }
}

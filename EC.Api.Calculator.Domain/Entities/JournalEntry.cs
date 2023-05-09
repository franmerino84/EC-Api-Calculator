using EC.Api.Calculator.Infrastructure.StaticAdapters;

namespace EC.Api.Calculator.Domain.Entities
{
    public class JournalEntry
    {
        public JournalEntry(string trackingId, string operation,  string calculation)
        {
            Id = Guid.NewGuid();
            TrackingId = trackingId;
            Operation = operation;
            Calculation = calculation;
            Timestamp = DateTimeProvider.Now;
        }

        public Guid Id { get; }
        public string TrackingId { get; }
        public string Operation { get; }
        public string Calculation { get; }
        public DateTime Timestamp { get; }

    }
}

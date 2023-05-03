using EC.Api.Calculator.Domain.Entities;

namespace EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories
{
    public interface IJournalEntryRepository
    {
        IEnumerable<JournalEntry> GetByTrackingId(string trackingId);
        void Insert(JournalEntry journalEntry);
    }
}

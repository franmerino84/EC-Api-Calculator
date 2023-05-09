using EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories;
using EC.Api.Calculator.Domain.Entities;
using System.Collections.Concurrent;

namespace EC.Api.Calculator.Infrastructure.Persistence.Repositories.JournalEntries
{
    public class JournalEntryRepository : IJournalEntryRepository
    {
        private readonly ConcurrentBag<JournalEntry> _journalEntries;

        public JournalEntryRepository()
        {
            _journalEntries = new ConcurrentBag<JournalEntry>();
        }

        public void Insert(JournalEntry journalEntry)
        {
            _journalEntries.Add(journalEntry);
        }

        public IEnumerable<JournalEntry> GetByTrackingId(string trackingId)
        {
            return _journalEntries
                .Where(x=>x.TrackingId == trackingId)
                .OrderBy(x=>x.Timestamp);
        }
    }
}

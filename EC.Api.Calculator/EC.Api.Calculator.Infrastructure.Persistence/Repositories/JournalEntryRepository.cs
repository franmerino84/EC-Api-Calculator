using EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories;
using EC.Api.Calculator.Domain.Entities;
using System.Collections.Concurrent;

namespace EC.Api.Calculator.Infrastructure.Persistence.Repositories
{
    public class JournalEntryRepository : IJournalEntryRepository
    {
        private readonly ConcurrentDictionary<string, List<JournalEntry>> _context;

        public JournalEntryRepository()
        {
            _context = new ConcurrentDictionary<string, List<JournalEntry>>();
        }

        public void Insert(JournalEntry journalEntry) 
        {
            lock (_context)
            {
                var journals = _context[journalEntry.TrackingId];

                journals ??= new List<JournalEntry>();

                journals.Add(journalEntry);

                _context[journalEntry.TrackingId] = journals;
            }
        }

        public IEnumerable<JournalEntry> GetByTrackingId(string trackingId) => 
            _context[trackingId];
    }
}

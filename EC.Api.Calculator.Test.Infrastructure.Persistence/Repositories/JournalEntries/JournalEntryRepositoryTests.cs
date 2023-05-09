using EC.Api.Calculator.Domain.Entities;
using EC.Api.Calculator.Infrastructure.Persistence.Repositories.JournalEntries;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Infrastructure.Persistence.Repositories.JournalEntries
{
    [TestFixture]
    [Category(Category.Unit)]
    public class JournalEntryRepositoryTests
    {
        [Test]
        public void Insert_Many_Then_GetByTrackingId_Returns_Proper_JournalEntries()
        {
            var trackingId = "trackingId";
            var journalEntry1 = new JournalEntry(trackingId, "operation1", "calculation1");
            var journalEntry2 = new JournalEntry(trackingId, "operation2", "calculation2");
            var journalEntry3 = new JournalEntry(trackingId, "operation3", "calculation3");

            var otherTrackingId = "otherTrackingId";
            var journalEntry4 = new JournalEntry(otherTrackingId, "operation4", "calculation4");
            var journalEntry5 = new JournalEntry(otherTrackingId, "operation5", "calculation5");
            var journalEntry6 = new JournalEntry(otherTrackingId, "operation6", "calculation6");

            var repository = new JournalEntryRepository();

            repository.Insert(journalEntry1);
            repository.Insert(journalEntry2);
            repository.Insert(journalEntry3);
            repository.Insert(journalEntry4);
            repository.Insert(journalEntry5); 
            repository.Insert(journalEntry6);

            var result = repository.GetByTrackingId(trackingId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Does.Contain(journalEntry1));
                Assert.That(result, Does.Contain(journalEntry2));
                Assert.That(result, Does.Contain(journalEntry3));
                Assert.That(result, Does.Not.Contain(journalEntry4));
                Assert.That(result, Does.Not.Contain(journalEntry5));
                Assert.That(result, Does.Not.Contain(journalEntry6));
            });

        }

        [Test]
        public void Insert_Many_Then_GetByTrackingId_Returns_JournalEntries_Ordered_By_Timestamp()
        {
            var trackingId = "trackingId";
            var journalEntry1 = new JournalEntry(trackingId, "operation1", "calculation1");
            var journalEntry2 = new JournalEntry(trackingId, "operation2", "calculation2");
            var journalEntry3 = new JournalEntry(trackingId, "operation3", "calculation3");

            var repository = new JournalEntryRepository();

            repository.Insert(journalEntry1);
            repository.Insert(journalEntry2);
            repository.Insert(journalEntry3);

            var result = repository.GetByTrackingId(trackingId).Select((x,index)=>new { x.Timestamp, Index = index });

            var reverseEvaluation = result.Any(x => result.Any(y => x.Timestamp > y.Timestamp && x.Index < y.Index));

            Assert.That(!reverseEvaluation, Is.True);
        }
    }
}

using EC.Api.Calculator.Domain.Entities;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Infrastructure.StaticAdapters;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.Entities
{
    [TestFixture]
    [Category(Category.Unit)]
    public class JournalEntryTests
    {
        [Test]
        public void Ctor_TrackingId_Is_Copied_To_Property()
        {
            var trackingId = "trackingId";
            var journalEntry = new JournalEntry(trackingId, "operation", "calculation");

            Assert.That(journalEntry.TrackingId, Is.EqualTo(trackingId));
        }

        [Test]
        public void Ctor_Operation_Is_Copied_To_Property()
        {
            var operation = "operation";
            var journalEntry = new JournalEntry("trackingId", operation, "calculation");

            Assert.That(journalEntry.Operation, Is.EqualTo(operation));
        }

        [Test]
        public void Ctor_Calculation_Is_Copied_To_Property()
        {
            var calculation = "calculation";
            var journalEntry = new JournalEntry("trackingId", "operation", calculation);

            Assert.That(journalEntry.Calculation, Is.EqualTo(calculation));
        }

        [Test]
        public void Ctor_Then_Id_Is_Not_Null()
        {
            var journalEntry = new JournalEntry("trackingId", "operation", "calculation");
            
            Assert.That(journalEntry.Id, Is.Not.EqualTo(default));
        }

        [Test]
        public void Ctor_Then_Timestamp_Is_DateTime_Now()
        {
            var now= DateTime.Now;
            DateTimeProvider.SetNow(()=>now);

            var journalEntry = new JournalEntry("trackingId", "operation", "calculation");

            Assert.That(journalEntry.Timestamp, Is.EqualTo(now));
        }


    }
}

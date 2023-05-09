namespace EC.Api.Calculator.Application.Journals.Queries.GetByTrackingId
{
    public class GetJournalByTrackingIdQueryResponse
    {
        public GetJournalByTrackingIdQueryResponse(IEnumerable<JournalOperation> operations)
        {
            Operations = operations;
        }

        public IEnumerable<JournalOperation> Operations { get; }
    }
}

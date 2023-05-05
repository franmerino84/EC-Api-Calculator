namespace EC.Api.Calculator.Application.Journals.GetById
{
    public class GetJournalByTrackingIdCommandResponse
    {
        public GetJournalByTrackingIdCommandResponse(IEnumerable<JournalOperation> operations)
        {
            Operations = operations;
        }

        public IEnumerable<JournalOperation> Operations { get; }
    }
}

using MediatR;

namespace EC.Api.Calculator.Application.Journals.Queries.GetByTrackingId
{
    public class GetJournalByTrackingIdQuery : IRequest<GetJournalByTrackingIdQueryResponse>
    {
        public GetJournalByTrackingIdQuery(string trackingId)
        {
            TrackingId = trackingId;
        }

        public string TrackingId { get; }
    }
}

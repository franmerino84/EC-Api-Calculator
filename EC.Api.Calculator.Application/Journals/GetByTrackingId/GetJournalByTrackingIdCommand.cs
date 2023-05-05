using MediatR;

namespace EC.Api.Calculator.Application.Journals.GetById
{
    public class GetJournalByTrackingIdCommand : IRequest<GetJournalByTrackingIdCommandResponse>
    {
        public GetJournalByTrackingIdCommand(string trackingId)
        {
            TrackingId = trackingId;
        }

        public string TrackingId { get; }
    }
}

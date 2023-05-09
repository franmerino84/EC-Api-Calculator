using AutoMapper;
using EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EC.Api.Calculator.Application.Journals.Queries.GetByTrackingId
{
    public class GetJournalByTrackingIdQueryHandler : IRequestHandler<GetJournalByTrackingIdQuery, GetJournalByTrackingIdQueryResponse>
    {
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetJournalByTrackingIdQueryHandler> _logger;

        public GetJournalByTrackingIdQueryHandler(IJournalEntryRepository journalEntryRepository, IMapper mapper, ILogger<GetJournalByTrackingIdQueryHandler> logger)
        {
            _journalEntryRepository = journalEntryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<GetJournalByTrackingIdQueryResponse> Handle(GetJournalByTrackingIdQuery request, CancellationToken cancellationToken)
        {
            Validate(request);

            var journalEntries = _journalEntryRepository.GetByTrackingId(request.TrackingId);

            var result = new GetJournalByTrackingIdQueryResponse(_mapper.Map<IEnumerable<JournalOperation>>(journalEntries));

            _logger.LogInformation("Journal successfully retrieved.");

            return Task.FromResult(result);
        }

        private void Validate(GetJournalByTrackingIdQuery request)
        {
            if (request == null)
            {
                _logger.LogError("Tried to retrieve a journal with null passed as parameter.");
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.TrackingId))
            {
                _logger.LogError("Tried to retrieve a journal with tracking id with value null or white space passed as parameter.");
                throw new DivideByZeroException("TrackingId cannot be null or white space");
            }
        }
    }
}

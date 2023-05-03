using AutoMapper;
using EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories;
using EC.Api.Calculator.Domain.Entities;
using EC.Api.Calculator.Domain.Services.CalculationFormatters.SquareRoots;
using EC.Api.Calculator.Domain.Services.OperationFormatters.SquareRoots;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EC.Api.Calculator.Application.Calculators.SquareRoots
{
    public class SquareRootCommandHandler : IRequestHandler<SquareRootCommand, SquareRootCommandResponse>
    {
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SquareRootCommandHandler> _logger;
        private readonly ISquareRootOperationFormatter _operationFormatter;
        private readonly ISquareRootCalculationFormatter _calculationFormatter;

        public SquareRootCommandHandler(IJournalEntryRepository journalEntryRepository, IMapper mapper, ILogger<SquareRootCommandHandler> logger,
            ISquareRootOperationFormatter operationFormatter, ISquareRootCalculationFormatter calculationFormatter)
        {
            _journalEntryRepository = journalEntryRepository;
            _mapper = mapper;
            _logger = logger;
            _operationFormatter = operationFormatter;
            _calculationFormatter = calculationFormatter;
        }

        public Task<SquareRootCommandResponse> Handle(SquareRootCommand request, CancellationToken cancellationToken)
        {
            Validate(request);
            
            var squareRoot = new SquareRoot(request.Number);

            if (request.TrackingId != null)
            {
                var journalEntry = new JournalEntry(request.TrackingId, _operationFormatter.FormatOperatorName(), _calculationFormatter.FormatOperation(squareRoot));

                _journalEntryRepository.Insert(journalEntry);

                _logger.LogInformation("Square root successfully stored in the journal.");
            }

            var result = _mapper.Map<SquareRootCommandResponse>(squareRoot);

            _logger.LogInformation("Square root successfully calculated.");

            return Task.FromResult(result);
        }

        private void Validate(SquareRootCommand request)
        {
            if (request == null)
            {
                _logger.LogError("Tried to calculate a square root with null passed as parameter.");
                throw new ArgumentNullException(nameof(request));
            }
        }
    }
}

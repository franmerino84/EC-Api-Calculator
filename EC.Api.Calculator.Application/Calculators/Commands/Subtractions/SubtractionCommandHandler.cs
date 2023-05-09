using AutoMapper;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories;
using EC.Api.Calculator.Domain.Entities;
using EC.Api.Calculator.Domain.Services.CalculationFormatters.Subtractions;
using EC.Api.Calculator.Domain.Services.OperationFormatters.Subtractions;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EC.Api.Calculator.Application.Calculators.Commands.Subtractions
{
    public class SubtractionCommandHandler : IRequestHandler<SubtractionCommand, SubtractionCommandResponse>
    {
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SubtractionCommandHandler> _logger;
        private readonly ISubtractionOperationFormatter _operationFormatter;
        private readonly ISubtractionCalculationFormatter _calculationFormatter;

        public SubtractionCommandHandler(IJournalEntryRepository journalEntryRepository, IMapper mapper, ILogger<SubtractionCommandHandler> logger,
            ISubtractionOperationFormatter operationFormatter, ISubtractionCalculationFormatter calculationFormatter)
        {
            _journalEntryRepository = journalEntryRepository;
            _mapper = mapper;
            _logger = logger;
            _operationFormatter = operationFormatter;
            _calculationFormatter = calculationFormatter;
        }

        public Task<SubtractionCommandResponse> Handle(SubtractionCommand request, CancellationToken cancellationToken)
        {
            Validate(request);

            var subtraction = new Subtraction(request.Minuend, request.Subtrahend);

            if (request.TrackingId != null)
            {
                var journalEntry = new JournalEntry(request.TrackingId, _operationFormatter.FormatOperatorName(), _calculationFormatter.FormatOperation(subtraction));

                try
                {
                    _journalEntryRepository.Insert(journalEntry);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Couldn't store the journal entry for a subtraction.");
                    throw new UnexpectedApplicationException(null, ex);
                }

                _logger.LogInformation("Subtraction successfully stored in the journal.");
            }

            var result = _mapper.Map<SubtractionCommandResponse>(subtraction);

            _logger.LogInformation("Subtraction successfully calculated.");

            return Task.FromResult(result);
        }

        private void Validate(SubtractionCommand request)
        {
            if (request == null)
            {
                _logger.LogError("Tried to calculate a subtraction with null passed as parameter.");
                throw new ArgumentNullException(nameof(request));
            }
        }
    }
}

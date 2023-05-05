using AutoMapper;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories;
using EC.Api.Calculator.Domain.Entities;
using EC.Api.Calculator.Domain.Services.CalculationFormatters.Divisions;
using EC.Api.Calculator.Domain.Services.OperationFormatters.Divisions;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EC.Api.Calculator.Application.Calculators.Divisions
{
    public class DivisionCommandHandler : IRequestHandler<DivisionCommand, DivisionCommandResponse>
    {
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DivisionCommandHandler> _logger;
        private readonly IDivisionOperationFormatter _operationFormatter;
        private readonly IDivisionCalculationFormatter _calculationFormatter;

        public DivisionCommandHandler(IJournalEntryRepository journalEntryRepository, IMapper mapper, ILogger<DivisionCommandHandler> logger,
            IDivisionOperationFormatter operationFormatter, IDivisionCalculationFormatter calculationFormatter)
        {
            _journalEntryRepository = journalEntryRepository;
            _mapper = mapper;
            _logger = logger;
            _operationFormatter = operationFormatter;
            _calculationFormatter = calculationFormatter;
        }

        public Task<DivisionCommandResponse> Handle(DivisionCommand request, CancellationToken cancellationToken)
        {
            Validate(request);

            var division = new Division(request.Dividend, request.Divisor);

            if (request.TrackingId != null)
            {
                var journalEntry = new JournalEntry(request.TrackingId, _operationFormatter.FormatOperatorName(), _calculationFormatter.FormatOperation(division));

                try
                {
                    _journalEntryRepository.Insert(journalEntry);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Couldn't store the journal entry for a division.");
                    throw new UnexpectedApplicationException(null, ex);
                }

                _logger.LogInformation("Division successfully stored in the journal.");
            }

            var result = _mapper.Map<DivisionCommandResponse>(division);

            _logger.LogInformation("Division successfully calculated.");

            return Task.FromResult(result);
        }

        private void Validate(DivisionCommand request)
        {
            if (request == null)
            {
                _logger.LogError("Tried to calculate a division with null passed as parameter.");
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Divisor == 0)
            {
                _logger.LogError("Tried to calculate a division with divisor value as 0.");
                throw new DivideByZeroException("Divisor cannot be zero");
            }
        }
    }
}

using AutoMapper;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories;
using EC.Api.Calculator.Domain.Entities;
using EC.Api.Calculator.Domain.Services.CalculationFormatters.Multiplications;
using EC.Api.Calculator.Domain.Services.OperationFormatters.Multiplications;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EC.Api.Calculator.Application.Calculators.Multiplications
{
    public class MultiplicationCommandHandler : IRequestHandler<MultiplicationCommand, MultiplicationCommandResponse>
    {
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MultiplicationCommandHandler> _logger;
        private readonly IMultiplicationOperationFormatter _operationFormatter;
        private readonly IMultiplicationCalculationFormatter _calculationFormatter;

        public MultiplicationCommandHandler(IJournalEntryRepository journalEntryRepository, IMapper mapper, ILogger<MultiplicationCommandHandler> logger,
            IMultiplicationOperationFormatter operationFormatter, IMultiplicationCalculationFormatter calculationFormatter)
        {
            _journalEntryRepository = journalEntryRepository;
            _mapper = mapper;
            _logger = logger;
            _operationFormatter = operationFormatter;
            _calculationFormatter = calculationFormatter;
        }

        public Task<MultiplicationCommandResponse> Handle(MultiplicationCommand request, CancellationToken cancellationToken)
        {
            Validate(request);

            var multiplication = new Multiplication(request.Factors);

            if (request.TrackingId != null)
            {
                var journalEntry = new JournalEntry(request.TrackingId, _operationFormatter.FormatOperatorName(), _calculationFormatter.FormatOperation(multiplication));

                try
                {
                    _journalEntryRepository.Insert(journalEntry);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Couldn't store the journal entry for a multiplication.");
                    throw new UnexpectedApplicationException(null, ex);
                }

                _logger.LogInformation("Multiplication successfully stored in the journal.");
            }

            var result = _mapper.Map<MultiplicationCommandResponse>(multiplication);

            _logger.LogInformation("Multiplication successfully calculated.");

            return Task.FromResult(result);
        }

        private void Validate(MultiplicationCommand request)
        {
            if (request == null)
            {
                _logger.LogError("Tried to calculate a multiplication with null passed as parameter.");
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Factors == null)
            {
                _logger.LogError("Tried to calculate a multiplication with factors field null passed as parameter.");
                throw new ArgumentException("Factors field cannot be null");
            }

            if (request.Factors.Count() < 2)
            {
                _logger.LogError("Tried to calculate a multiplication with less than 2 factors passed as parameter.");
                throw new NotEnoughOperandsException("Factors field requires at least two operands");
            }
        }
    }
}

using AutoMapper;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Domain.Abstractions.Persistence.Repositories;
using EC.Api.Calculator.Domain.Entities;
using EC.Api.Calculator.Domain.Services.CalculationFormatters.Additions;
using EC.Api.Calculator.Domain.Services.OperationFormatters.Additions;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EC.Api.Calculator.Application.Calculators.Commands.Additions
{
    public class AdditionCommandHandler : IRequestHandler<AdditionCommand, AdditionCommandResponse>
    {
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AdditionCommandHandler> _logger;
        private readonly IAdditionOperationFormatter _operationFormatter;
        private readonly IAdditionCalculationFormatter _calculationFormatter;

        public AdditionCommandHandler(IJournalEntryRepository journalEntryRepository, IMapper mapper, ILogger<AdditionCommandHandler> logger,
            IAdditionOperationFormatter operationFormatter, IAdditionCalculationFormatter calculationFormatter)
        {
            _journalEntryRepository = journalEntryRepository;
            _mapper = mapper;
            _logger = logger;
            _operationFormatter = operationFormatter;
            _calculationFormatter = calculationFormatter;
        }

        public Task<AdditionCommandResponse> Handle(AdditionCommand request, CancellationToken cancellationToken)
        {
            Validate(request);

            var addition = new Addition(request.Addends);

            if (request.TrackingId != null)
            {
                var journalEntry = new JournalEntry(request.TrackingId, _operationFormatter.FormatOperatorName(), _calculationFormatter.FormatCalculation(addition));

                try
                {
                    _journalEntryRepository.Insert(journalEntry);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Couldn't store the journal entry for an addition.");
                    throw new UnexpectedApplicationException(null, ex);
                }

                _logger.LogInformation("Addition successfully stored in the journal.");
            }

            var result = _mapper.Map<AdditionCommandResponse>(addition);

            _logger.LogInformation("Addition successfully calculated.");

            return Task.FromResult(result);
        }

        private void Validate(AdditionCommand request)
        {
            if (request == null)
            {
                _logger.LogError("Tried to calculate an addition with null passed as parameter.");
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Addends == null)
            {
                _logger.LogError("Tried to calculate an addition with addends field null passed as parameter.");
                throw new ArgumentException("Addends field cannot be null");
            }

            if (request.Addends.Count() < 2)
            {
                _logger.LogError("Tried to calculate an addition with less than 2 addends passed as parameter.");
                throw new NotEnoughOperandsException("Addends field requires at least two operands");
            }
        }
    }
}

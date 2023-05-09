using MediatR;

namespace EC.Api.Calculator.Application.Calculators.Commands.Multiplications
{
    public class MultiplicationCommand : IRequest<MultiplicationCommandResponse>
    {
        public MultiplicationCommand(IEnumerable<int> factors) : this(factors, null) { }

        public MultiplicationCommand(IEnumerable<int> factors, string? trackingId)
        {
            Factors = factors;
            TrackingId = trackingId;
        }

        public IEnumerable<int> Factors { get; }
        public string? TrackingId { get; }
    }
}

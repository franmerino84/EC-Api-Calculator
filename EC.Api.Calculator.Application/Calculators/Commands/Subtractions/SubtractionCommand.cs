using MediatR;

namespace EC.Api.Calculator.Application.Calculators.Commands.Subtractions
{
    public class SubtractionCommand : IRequest<SubtractionCommandResponse>
    {
        public SubtractionCommand(int minuend, int subtrahend) : this(minuend, subtrahend, null) { }

        public SubtractionCommand(int minuend, int subtrahend, string? trackingId)
        {
            Minuend = minuend;
            Subtrahend = subtrahend;
            TrackingId = trackingId;
        }

        public int Minuend { get; }
        public int Subtrahend { get; }
        public string? TrackingId { get; }
    }
}

using MediatR;

namespace EC.Api.Calculator.Application.Calculators.Commands.SquareRoots
{
    public class SquareRootCommand : IRequest<SquareRootCommandResponse>
    {
        public SquareRootCommand(int number) : this(number, null) { }
        public SquareRootCommand(int number, string? trackingId)
        {
            Number = number;
            TrackingId = trackingId;
        }

        public int Number { get; }
        public string? TrackingId { get; }
    }
}

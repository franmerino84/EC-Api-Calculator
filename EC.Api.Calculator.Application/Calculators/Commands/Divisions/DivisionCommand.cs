using MediatR;

namespace EC.Api.Calculator.Application.Calculators.Commands.Divisions
{
    public class DivisionCommand : IRequest<DivisionCommandResponse>
    {
        public DivisionCommand(int dividend, int divisor) : this(dividend, divisor, null) { }

        public DivisionCommand(int dividend, int divisor, string? trackingId)
        {
            Dividend = dividend;
            Divisor = divisor;
            TrackingId = trackingId;
        }

        public int Dividend { get; }
        public int Divisor { get; }
        public string? TrackingId { get; }
    }
}

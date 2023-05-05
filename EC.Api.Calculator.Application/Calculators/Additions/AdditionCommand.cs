using MediatR;

namespace EC.Api.Calculator.Application.Calculators.Additions
{
    public class AdditionCommand : IRequest<AdditionCommandResponse>
    {
        public AdditionCommand(IEnumerable<int> addends) : this(addends, null) { }

        public AdditionCommand(IEnumerable<int> addends, string? trackingId)
        {
            Addends = addends;
            TrackingId = trackingId;
        }

        public IEnumerable<int> Addends { get; }
        public string? TrackingId { get; }
    }
}

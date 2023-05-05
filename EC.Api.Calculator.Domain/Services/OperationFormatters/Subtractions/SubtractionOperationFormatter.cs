using EC.Api.Calculator.Domain.Services.OperationFormatters.Subtractions;

namespace EC.Api.Calculator.Domain.Services.OperatorFormatter
{
    public class SubtractionOperationFormatter : ISubtractionOperationFormatter
    {
        public string FormatOperatorName() =>
            "Sub";
    }
}

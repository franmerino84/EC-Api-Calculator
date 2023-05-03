using EC.Api.Calculator.Domain.Services.OperationFormatters.Multiplications;

namespace EC.Api.Calculator.Domain.Services.OperatorFormatter
{
    public class MultiplicationOperationFormatter : IMultiplicationOperationFormatter
    {
        public string FormatOperatorName() =>
            "Mul";
    }
}

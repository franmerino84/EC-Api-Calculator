using EC.Api.Calculator.Domain.Services.OperationFormatters.SquareRoots;

namespace EC.Api.Calculator.Domain.Services.OperatorFormatter
{
    public class SquareRootOperationFormatter : ISquareRootOperationFormatter
    {
        public string FormatOperatorName() =>
            "Sqr";
    }
}

using EC.Api.Calculator.Domain.Services.CalculationFormatters.SquareRoots;
using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Domain.Services.OperationFormatters
{
    public class SquareRootCalculationFormatter : ISquareRootCalculationFormatter
    {
        public string FormatOperation(SquareRoot operation) => 
            $"Sqrt {operation.Number} = {operation.Square}";
    }
}

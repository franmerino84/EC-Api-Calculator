using EC.Api.Calculator.Domain.Services.CalculationFormatters.Subtractions;
using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Domain.Services.OperationFormatters
{
    public class SubtractionCalculationFormatter : ISubtractionCalculationFormatter
    {
        public string FormatOperation(Subtraction operation) => 
            $"{operation.Minuend} - {operation.Subtrahend} = {operation.Difference}";
    }
}

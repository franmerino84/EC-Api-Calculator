using EC.Api.Calculator.Domain.Services.CalculationFormatters.Multiplications;
using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Domain.Services.OperationFormatters
{
    public class MultiplicationCalculationFormatter : IMultiplicationCalculationFormatter
    {
        public string FormatCalculation(Multiplication operation) => 
            $"{string.Join(" * ", operation.Factors)} = {operation.Product}";
    }
}

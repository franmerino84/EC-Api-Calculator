using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Domain.Services.CalculationFormatters.Additions
{
    public class AdditionCalculationFormatter : IAdditionCalculationFormatter
    {
        public string FormatCalculation(Addition addition) =>
            $"{string.Join(" + ", addition.Addends)} = {addition.Sum}";
    }
}

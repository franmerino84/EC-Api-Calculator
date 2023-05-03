using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Domain.Services.CalculationFormatters.Divisions
{
    public class DivisionCalculationFormatter : IDivisionCalculationFormatter
    {
        public string FormatOperation(Division operation) =>
            $"{operation.Dividend} / {operation.Divisor} = {operation.Quotient} % {operation.Remainder}";
    }
}

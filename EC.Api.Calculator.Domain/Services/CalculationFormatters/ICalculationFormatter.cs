using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Domain.Services.OperationFormatters
{
    public interface ICalculationFormatter<T> where T : Operation
    {
        string FormatCalculation(T operation);
    }
}
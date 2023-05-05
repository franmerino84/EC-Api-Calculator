using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Domain.Services.OperatorFormatter
{
    public interface IOperationFormatter<T> where T : Operation
    {
        string FormatOperatorName();
    }
}

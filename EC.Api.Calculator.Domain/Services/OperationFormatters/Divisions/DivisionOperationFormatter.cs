using EC.Api.Calculator.Domain.Services.OperationFormatters.Divisions;

namespace EC.Api.Calculator.Domain.Services.OperatorFormatter
{
    public class DivisionOperationFormatter : IDivisionOperationFormatter
    {
        public string FormatOperatorName() => 
            "Div";
    }
}

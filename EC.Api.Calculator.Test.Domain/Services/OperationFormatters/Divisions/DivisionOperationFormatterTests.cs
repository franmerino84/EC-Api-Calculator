using EC.Api.Calculator.Domain.Services.OperatorFormatter;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.Services.OperationFormatters.Divisions
{
    [TestFixture]
    [Category(Category.Unit)]
    public class DivisionOperationFormatterTests
    {
        [Test]
        public void FormatOperatorName_Div()
        {
            var result = new DivisionOperationFormatter().FormatOperatorName();

            Assert.That(result, Is.EqualTo("Div"));
        }
    }
}

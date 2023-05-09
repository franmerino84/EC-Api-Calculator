using EC.Api.Calculator.Domain.Services.OperatorFormatter;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.Services.OperationFormatters.Multiplications
{
    [TestFixture]
    [Category(Category.Unit)]
    public class MultiplicationOperationFormatterTests
    {
        [Test]
        public void FormatOperatorName_Mul()
        {
            var result = new MultiplicationOperationFormatter().FormatOperatorName();

            Assert.That(result, Is.EqualTo("Mul"));
        }
    }
}

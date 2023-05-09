using EC.Api.Calculator.Domain.Services.OperationFormatters.Additions;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.Services.OperationFormatters.Additions
{
    [TestFixture]
    [Category(Category.Unit)]
    public class AdditionOperationFormatterTests
    {
        [Test]
        public void FormatOperatorName_Sum()
        {
            var result = new AdditionOperationFormatter().FormatOperatorName();

            Assert.That(result, Is.EqualTo("Sum"));
        }
    }
}

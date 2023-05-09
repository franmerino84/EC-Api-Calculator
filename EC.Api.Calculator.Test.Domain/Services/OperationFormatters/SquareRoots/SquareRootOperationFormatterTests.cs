using EC.Api.Calculator.Domain.Services.OperatorFormatter;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.Services.OperationFormatters.SquareRoots
{
    [TestFixture]
    [Category(Category.Unit)]
    public class SquareRootOperationFormatterTests
    {
        [Test]
        public void FormatOperatorName_Sqr()
        {
            var result = new SquareRootOperationFormatter().FormatOperatorName();

            Assert.That(result, Is.EqualTo("Sqr"));
        }
    }
}

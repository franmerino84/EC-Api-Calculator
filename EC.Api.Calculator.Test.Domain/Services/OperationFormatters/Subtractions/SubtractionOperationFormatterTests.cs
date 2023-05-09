using EC.Api.Calculator.Domain.Services.OperatorFormatter;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.Services.OperationFormatters.Subtractions
{
    [TestFixture]
    [Category(Category.Unit)]
    public class SubtractionOperationFormatterTests
    {
        [Test]
        public void FormatOperatorName_Sub()
        {
            var result = new SubtractionOperationFormatter().FormatOperatorName();

            Assert.That(result, Is.EqualTo("Sub"));
        }
    }
}

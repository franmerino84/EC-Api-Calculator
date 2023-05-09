using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.ValueObjects.Operations
{
    [TestFixture]
    [Category(Category.Unit)]
    public class DivisionTests
    {
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(105, 10)]
        public void Ctor_Dividend_Is_Copied_To_Property(int dividend, int divisor)
        {
            var division = new Division(dividend, divisor);

            Assert.That(division.Dividend, Is.EqualTo(dividend));
        }

        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(105, 10)]
        public void Ctor_Divisor_Is_Copied_To_Property(int dividend, int divisor)
        {
            var division = new Division(dividend, divisor);

            Assert.That(division.Divisor, Is.EqualTo(divisor));
        }

        [TestCase(2, 0, 4, 2)]
        [TestCase(2, 1, 5, 2)]
        [TestCase(10, 5, 105, 10)]
        public void Assert_Known_Divisions(int expectedQuotient, int expectedRemainder, int dividend, int divisor)
        {
            var division = new Division(dividend, divisor);
            Assert.Multiple(() =>
            {
                Assert.That(division.Quotient, Is.EqualTo(expectedQuotient));
                Assert.That(division.Remainder, Is.EqualTo(expectedRemainder));
            });
        }

        [Test]
        public void Assert_Ctor_With_Divisor_Zero_Throws_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Division(5, 0));
        }

        [Test]
        public void Assert_Divisions_With_Same_Parameters_Are_Equal()
        {
            var division1 = new Division(5, 2);
            var division2 = new Division(5, 2);

            Assert.That(division1, Is.EqualTo(division2));
        }
    }
}

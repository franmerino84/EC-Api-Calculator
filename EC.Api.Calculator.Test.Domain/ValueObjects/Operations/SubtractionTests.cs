using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.ValueObjects.Operations
{
    [TestFixture]
    [Category(Category.Unit)]
    public class SubtractionTests
    {
        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(105, 10)]
        public void Ctor_Minuend_Is_Copied_To_Property(int minuend, int subtrahend)
        {
            var subtraction = new Subtraction(minuend, subtrahend);

            Assert.That(subtraction.Minuend, Is.EqualTo(minuend));
        }

        [TestCase(4, 2)]
        [TestCase(5, 2)]
        [TestCase(105, 10)]
        public void Ctor_Subtrahend_Is_Copied_To_Property(int minuend, int subtrahend)
        {
            var subtraction = new Subtraction(minuend, subtrahend);

            Assert.That(subtraction.Subtrahend, Is.EqualTo(subtrahend));
        }

        [TestCase(2, 4, 2)]
        [TestCase(3, 5, 2)]
        [TestCase(95, 105, 10)]
        [TestCase(-5, 5, 10)]
        public void Assert_Known_Subtractions(int expected, int minuend, int subtrahend)
        {
            var subtraction = new Subtraction(minuend, subtrahend);

            Assert.That(subtraction.Difference, Is.EqualTo(expected));
        }

        [Test]
        public void Assert_Subtractions_With_Same_Parameters_Are_Equal()
        {
            var subtraction1 = new Subtraction(5, 2);
            var subtraction2 = new Subtraction(5, 2);

            Assert.That(subtraction1, Is.EqualTo(subtraction2));
        }
    }
}

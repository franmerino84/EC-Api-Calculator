using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.ValueObjects.Operations
{
    [TestFixture]
    [Category(Category.Unit)]
    public class MultiplicationTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 3)]
        [TestCase(1, 2, 3, 4)]
        [TestCase(1, -1)]
        public void Ctor_Factors_Are_Copied_To_Property(params int[] factors)
        {
            var multiplication = new Multiplication(factors);

            Assert.That(multiplication.Factors, Is.EquivalentTo(factors));
        }

        [TestCase(1, 1, 1)]
        [TestCase(6, 2, 3)]
        [TestCase(24, 1, 2, 3, 4)]
        [TestCase(-1, 1, -1)]
        public void Assert_Known_Multiplications(int expected, params int[] factors)
        {
            var multiplication = new Multiplication(factors);

            Assert.That(multiplication.Product, Is.EqualTo(expected));
        }

        [Test]
        public void Assert_Ctor_With_Null_Factors_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Multiplication(null));
        }

        [Test]
        public void Assert_Multiplications_With_Same_Parameters_Are_Equal()
        {
            var multiplication1 = new Multiplication(new[] { 1, 2 });
            var multiplication2 = new Multiplication(new[] { 1, 2 });

            Assert.That(multiplication1, Is.EqualTo(multiplication2));
        }
    }
}

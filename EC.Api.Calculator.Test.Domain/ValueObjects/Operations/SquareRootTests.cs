using EC.Api.Calculator.Domain.Exceptions;
using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.ValueObjects.Operations
{
    [TestFixture]
    [Category(Category.Unit)]
    public class SquareRootTests
    {
        [TestCase(4)]
        [TestCase(9)]
        [TestCase(16)]
        public void Ctor_Addends_Are_Copied_To_Property(int number)
        {
            var squareRoot = new SquareRoot(number);

            Assert.That(squareRoot.Number, Is.EqualTo(number));
        }

        [TestCase(2, 4)]
        [TestCase(3, 9)]
        [TestCase(4, 16)]
        public void Assert_Known_SquareRoots(int expected, int number)
        {
            var squareRoot = new SquareRoot(number);

            Assert.That(squareRoot.Square, Is.EqualTo(expected));
        }

        [Test]
        public void Assert_Ctor_With_Number_With_Not_Exact_SquareRoot_Throws_SquareRootNotExactException()
        {
            Assert.Throws<SquareRootNotExactException>(() => new SquareRoot(5));
        }

        [Test]
        public void Assert_SquareRoots_With_Same_Parameters_Are_Equal()
        {
            var squareRoot1 = new SquareRoot(9);
            var squareRoot2 = new SquareRoot(9);

            Assert.That(squareRoot1, Is.EqualTo(squareRoot2));
        }
    }
}

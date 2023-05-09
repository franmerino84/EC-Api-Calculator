using EC.Api.Calculator.Domain.ValueObjects.Operations;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Domain.ValueObjects.Operations
{
    [TestFixture]
    [Category(Category.Unit)]
    public class AdditionTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 3)]
        [TestCase(1, 2, 3, 4)]
        [TestCase(1, -1)]
        public void Ctor_Addends_Are_Copied_To_Property(params int[] addends)
        {
            var addition = new Addition(addends);

            Assert.That(addition.Addends, Is.EquivalentTo(addends));
        }


        [TestCase(2, 1, 1)]
        [TestCase(5, 2, 3)]
        [TestCase(10, 1, 2, 3, 4)]
        [TestCase(0, 1, -1)]
        public void Assert_Known_Additions(int expected, params int[] addends)
        {
            var addition = new Addition(addends);

            Assert.That(addition.Sum, Is.EqualTo(expected));
        }

        [Test]
        public void Assert_Ctor_With_Null_Addends_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Addition(null));
        }

        [Test]
        public void Assert_Additions_With_Same_Parameters_Are_Equal()
        {
            var addition1 = new Addition(new[] { 1, 2 });
            var addition2 = new Addition(new[] { 1, 2 });

            Assert.That(addition1, Is.EqualTo(addition2));
        }
    }
}

using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.SquareRoots.Dtos;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Journals.Query.Dtos;
using EC.Api.Calculator.Test.Helpers;

namespace EC.Api.Calculator.Test.Presentation.WebApi.Controllers.Journals.Dtos
{
    [TestFixture]
    [Category(Category.Unit)]
    public class JournalQueryRequestDtoTests
    {
        [TestCase("id")]
        [TestCase("hello")]
        [TestCase("world")]
        public void Ctor_Id_Is_Copied_To_Property(string id)
        {
            var request = new JournalQueryRequestDto(id);

            Assert.That(request.Id, Is.EqualTo(id));
        }

    }
}

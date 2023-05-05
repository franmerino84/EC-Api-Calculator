namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Journals.Query
{
    public class JournalQueryRequestDto
    {
        public JournalQueryRequestDto(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}

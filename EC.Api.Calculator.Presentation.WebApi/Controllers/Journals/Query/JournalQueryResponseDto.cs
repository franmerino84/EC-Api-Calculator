namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Journals.Query
{
    public class JournalQueryResponseDto
    {
        public JournalQueryResponseDto(IEnumerable<JournalQueryOperation> operations)
        {
            Operations = operations;
        }

        public IEnumerable<JournalQueryOperation> Operations { get; }
    }
}

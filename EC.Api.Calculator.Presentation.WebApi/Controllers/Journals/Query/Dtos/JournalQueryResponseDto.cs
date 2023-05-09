namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Journals.Query.Dtos
{
    public class JournalQueryResponseDto
    {
        public JournalQueryResponseDto(IEnumerable<JournalQueryOperationDto> operations)
        {
            Operations = operations;
        }

        public IEnumerable<JournalQueryOperationDto> Operations { get; }
    }
}

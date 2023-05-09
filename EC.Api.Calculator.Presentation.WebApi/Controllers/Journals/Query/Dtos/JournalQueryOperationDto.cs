namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Journals.Query.Dtos
{
    public class JournalQueryOperationDto
    {
        public JournalQueryOperationDto(string operation, string calculation, DateTime date)
        {
            Operation = operation;
            Calculation = calculation;
            Date = date;
        }

        public string Operation { get; }
        public string Calculation { get; }
        public DateTime Date { get; }
    }
}

namespace EC.Api.Calculator.Application.Journals
{
    public class JournalOperation
    {
        public JournalOperation(string operation, string calculation, DateTime date)
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
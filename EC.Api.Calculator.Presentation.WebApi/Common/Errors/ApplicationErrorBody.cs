namespace EC.Api.Calculator.Presentation.WebApi.Common.Errors
{
    public class ApplicationErrorBody
    {
        public ApplicationErrorBody(string errorCode, int httpStatusCode, string message)
        {
            ErrorCode = errorCode;
            HttpStatusCode = httpStatusCode;
            Message = message;
        }

        public string ErrorCode { get; }
        public int HttpStatusCode { get; }
        public string Message { get; }
    }
}
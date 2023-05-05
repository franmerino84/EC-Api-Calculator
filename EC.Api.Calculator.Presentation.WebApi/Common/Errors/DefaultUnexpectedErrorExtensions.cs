using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EC.Api.Calculator.Presentation.WebApi.Common.Errors
{
    public static class DefaultUnexpectedErrorExtensions
    {
        public static ObjectResult DefaultUnexpectedError(this ControllerBase controller) => 
            controller.StatusCode(StatusCodes.Status500InternalServerError,
                    new ApplicationErrorBody(
                        ErrorCode.Unexpected,
                        (int)HttpStatusCode.InternalServerError,
                        $"An unexpected error occurred during the process of the request."
                        ));
    }
}

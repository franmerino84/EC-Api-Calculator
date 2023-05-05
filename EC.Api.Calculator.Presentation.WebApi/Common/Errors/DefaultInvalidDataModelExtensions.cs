using Microsoft.AspNetCore.Mvc;
using System.Net;
#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace EC.Api.Calculator.Presentation.WebApi.Common.Errors
{
    public static class DefaultInvalidDataModelExtensions
    {
        public static UnprocessableEntityObjectResult GetDefaultInvalidDataModelUnprocessableEntityObjectResult(this ActionContext context) 
        { 
            return new UnprocessableEntityObjectResult(
                            new ApplicationErrorBody(
                                ErrorCode.InvalidDataModel,
                                (int)HttpStatusCode.UnprocessableEntity,
                                GetErrorMessage(context)));
        }

        private static string GetErrorMessage(ActionContext context)
        {
            var matchingTypeFailingKeys = context.ModelState.Keys.Where(x => x.StartsWith("$.")).Select(x => x[2..]);

            if (matchingTypeFailingKeys.Any())
                return string.Join(" | ", matchingTypeFailingKeys.Select(x =>
                    $"The field {x} expects a value of type {context.ActionDescriptor.Parameters.First(x=>x.Name=="requestDto").ParameterType.GetProperty(x).PropertyType.Name}"));
            else
                return string.Join(" | ", context.ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage));
        }
    }
}

#pragma warning restore CS8602 // Dereference of a possibly null reference.

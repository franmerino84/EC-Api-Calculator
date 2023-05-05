using EC.Api.Calculator.Application.Calculators.SquareRoots;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Domain.Exceptions;
using EC.Api.Calculator.Presentation.WebApi.Common;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.SquareRoots;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators
{
    public partial class CalculatorController : ControllerBase
    {
        [HttpPost]
        [Route("sqrt")]
        public async Task<IActionResult> SquareRoot([FromBody] CalculatorSquareRootRequestDto requestDto, [FromHeader(Name = Header.TrackingId)] string? trackingId)
        {
            try
            {
                var command = new SquareRootCommand(requestDto.Number, trackingId);

                var response = await _mediator.Send(command);

                var responseDto = _mapper.Map<CalculatorSquareRootResponseDto>(response);

                return Ok(responseDto);
            }
            catch (SquareRootNotExactException)
            {
                return UnprocessableEntity(
                    new ApplicationErrorBody(
                        ErrorCode.InvalidDataModel, 
                        (int)HttpStatusCode.UnprocessableEntity, 
                        $"The square root of {requestDto.Number} is not exact."));
            }
            catch (UnexpectedApplicationException)
            {
                return this.DefaultUnexpectedError();
            }
        }
    }
}

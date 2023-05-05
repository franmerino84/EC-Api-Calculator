using EC.Api.Calculator.Application.Calculators.SquareRoots;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Domain.Exceptions;
using EC.Api.Calculator.Presentation.WebApi.Common;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.SquareRoots;
using Microsoft.AspNetCore.Mvc;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators
{
    public partial class CalculatorController : ControllerBase
    {
        [HttpPost]
        [Route("sqrt")]
        public async Task<IActionResult> SquareRoot([FromBody] CalculatorSquareRootRequestDto requestDto, [FromHeader(Name = Headers.TrackingId)] string? trackingId)
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
                return BadRequest($"The square root of {requestDto.Number} is not exact");
            }
            catch (UnexpectedApplicationException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

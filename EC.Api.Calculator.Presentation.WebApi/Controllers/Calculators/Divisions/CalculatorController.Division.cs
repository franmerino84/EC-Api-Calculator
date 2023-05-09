using EC.Api.Calculator.Application.Calculators.Divisions;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Presentation.WebApi.Common;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Divisions.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators
{
    public partial class CalculatorController : ControllerBase
    {
        [HttpPost]
        [Route("div")]
        public async Task<IActionResult> Division([FromBody] CalculatorDivisionRequestDto requestDto, [FromHeader(Name = Header.TrackingId)] string? trackingId)
        {
            try
            {
                var command = new DivisionCommand(requestDto.Dividend, requestDto.Divisor, trackingId);

                var response = await _mediator.Send(command);

                var responseDto = _mapper.Map<CalculatorDivisionResponseDto>(response);

                return Ok(responseDto);
            }
            catch (UnexpectedApplicationException)
            {
                return this.DefaultUnexpectedError();
            }
        }
    }
}

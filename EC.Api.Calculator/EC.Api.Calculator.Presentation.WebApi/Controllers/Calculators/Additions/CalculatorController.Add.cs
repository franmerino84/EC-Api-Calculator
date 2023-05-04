using EC.Api.Calculator.Application.Calculators.Additions;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Additions;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators
{
    public partial class CalculatorController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CalculatorAddRequestDto requestDto, [FromHeader(Name = "X-Evi-Tracking-Id")] string? trackingId)
         {
            var command = new AdditionCommand(requestDto.Addends, trackingId);
            
            var response = await _mediator.Send(command);

            var responseDto = _mapper.Map<CalculatorAddResponseDto>(response);

            return Ok(responseDto);
        }
    }
}

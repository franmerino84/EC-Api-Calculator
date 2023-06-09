﻿using EC.Api.Calculator.Application.Calculators.Commands.Additions;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Presentation.WebApi.Common;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Additions.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators
{
    public partial class CalculatorController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Addition([FromBody] CalculatorAdditionRequestDto requestDto, [FromHeader(Name = Header.TrackingId)] string? trackingId)
        {
            try
            {
                var command = new AdditionCommand(requestDto.Addends, trackingId);

                var response = await _mediator.Send(command);

                var responseDto = _mapper.Map<CalculatorAdditionResponseDto>(response);

                return Ok(responseDto);
            }
            catch (UnexpectedApplicationException)
            {
                return this.DefaultUnexpectedError();
            }
        }
    }
}

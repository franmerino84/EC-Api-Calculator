﻿using EC.Api.Calculator.Application.Calculators.Commands.Multiplications;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Presentation.WebApi.Common;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Multiplications.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators
{
    public partial class CalculatorController : ControllerBase
    {
        [HttpPost]
        [Route("mult")]
        public async Task<IActionResult> Multiplication([FromBody] CalculatorMultiplicationRequestDto requestDto, [FromHeader(Name = Header.TrackingId)] string? trackingId)
        {
            try
            {
                var command = new MultiplicationCommand(requestDto.Factors,trackingId);

                var response = await _mediator.Send(command);

                var responseDto = _mapper.Map<CalculatorMultiplicationResponseDto>(response);

                return Ok(responseDto);
            }
            catch (UnexpectedApplicationException)
            {
                return this.DefaultUnexpectedError();
            }
        }
    }
}

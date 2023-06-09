﻿using EC.Api.Calculator.Application.Calculators.Commands.Subtractions;
using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Presentation.WebApi.Common;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Subtractions.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators
{
    public partial class CalculatorController : ControllerBase
    {
        [HttpPost]
        [Route("sub")]
        public async Task<IActionResult> Subtraction([FromBody] CalculatorSubtractionRequestDto requestDto, [FromHeader(Name = Header.TrackingId)] string? trackingId)
        {
            try
            {
                var command = new SubtractionCommand(requestDto.Minuend, requestDto.Subtrahend, trackingId);

                var response = await _mediator.Send(command);

                var responseDto = _mapper.Map<CalculatorSubtractionResponseDto>(response);

                return Ok(responseDto);
            }
            catch (UnexpectedApplicationException)
            {
                return this.DefaultUnexpectedError();
            }
        }
    }
}

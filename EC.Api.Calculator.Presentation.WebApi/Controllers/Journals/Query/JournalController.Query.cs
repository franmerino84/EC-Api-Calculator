using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Application.Journals.Queries.GetByTrackingId;
using EC.Api.Calculator.Presentation.WebApi.Common.Errors;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Journals.Query.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Journals
{
    public partial class JournalController : ControllerBase
    {
        [HttpPost]
        [Route("query")]
        public async Task<IActionResult> Query([FromBody] JournalQueryRequestDto requestDto)
        {
            try
            {
                var command = new GetJournalByTrackingIdQuery(requestDto.Id);

                var response = await _mediator.Send(command);

                var responseDto = _mapper.Map<JournalQueryResponseDto>(response);

                return Ok(responseDto);
            }
            catch (UnexpectedApplicationException)
            {
                return this.DefaultUnexpectedError();
            }
        }
    }
}

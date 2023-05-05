using EC.Api.Calculator.Application.Exceptions;
using EC.Api.Calculator.Application.Journals.GetById;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Journals.Query;
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
                var command = new GetJournalByTrackingIdCommand(requestDto.Id);

                var response = await _mediator.Send(command);

                var responseDto = _mapper.Map<JournalQueryResponseDto>(response);

                return Ok(responseDto);
            }
            catch (UnexpectedApplicationException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

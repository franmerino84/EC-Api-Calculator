using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Journals
{
    [Route("[controller]")]
    [ApiController]
    public partial class JournalController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public JournalController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
    }
}

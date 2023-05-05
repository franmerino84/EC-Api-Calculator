using AutoMapper;
using EC.Api.Calculator.Application.Journals;
using EC.Api.Calculator.Application.Journals.GetById;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Journals.Query
{
    public class JournalQueryMappingProfile : Profile
    {
        public JournalQueryMappingProfile()
        {
            CreateMap<JournalOperation, JournalQueryOperation>();
            CreateMap<GetJournalByTrackingIdCommandResponse, JournalQueryResponseDto>();
        }
    }
}

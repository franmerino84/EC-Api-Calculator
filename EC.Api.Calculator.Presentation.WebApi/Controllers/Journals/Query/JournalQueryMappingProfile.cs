using AutoMapper;
using EC.Api.Calculator.Application.Journals;
using EC.Api.Calculator.Application.Journals.GetById;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Journals.Query.Dtos;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Journals.Query
{
    public class JournalQueryMappingProfile : Profile
    {
        public JournalQueryMappingProfile()
        {
            CreateMap<JournalOperation, JournalQueryOperationDto>();
            CreateMap<GetJournalByTrackingIdCommandResponse, JournalQueryResponseDto>();
        }
    }
}

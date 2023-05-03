using AutoMapper;
using EC.Api.Calculator.Application.Journals;
using EC.Api.Calculator.Domain.Entities;

namespace EC.Api.Calculator.Application.Calculators.Additions
{
    public class GetJournalsByTrackingIdProfile : Profile
    {
        public GetJournalsByTrackingIdProfile()
        {
            CreateMap<JournalEntry, JournalOperation>();
        }
    }
}
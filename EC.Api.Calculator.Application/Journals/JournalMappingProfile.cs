using AutoMapper;
using EC.Api.Calculator.Domain.Entities;

namespace EC.Api.Calculator.Application.Journals
{
    public class JournalMappingProfile : Profile
    {
        public JournalMappingProfile()
        {
            CreateMap<JournalEntry, JournalOperation>()
                .ConstructUsing(x => new JournalOperation(x.Operation, x.Calculation, x.Timestamp));
        }
    }
}
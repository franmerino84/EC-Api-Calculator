using AutoMapper;
using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Application.Calculators.Commands.Additions
{
    public class DivisionMappingProfile : Profile
    {
        public DivisionMappingProfile()
        {
            CreateMap<Addition, AdditionCommandResponse>();
        }
    }
}
using AutoMapper;
using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Application.Calculators.Commands.Divisions
{
    public class MultiplicationMappingProfile : Profile
    {
        public MultiplicationMappingProfile()
        {
            CreateMap<Division, DivisionCommandResponse>();
        }
    }
}
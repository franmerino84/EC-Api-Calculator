using AutoMapper;
using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Application.Calculators.Commands.Subtractions
{
    public class SubtractionMappingProfile : Profile
    {
        public SubtractionMappingProfile()
        {
            CreateMap<Subtraction, SubtractionCommandResponse>();
        }
    }
}
using AutoMapper;
using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Application.Calculators.Commands.SquareRoots
{
    public class SubtractionMappingProfile : Profile
    {
        public SubtractionMappingProfile()
        {
            CreateMap<SquareRoot, SquareRootCommandResponse>();
        }
    }
}
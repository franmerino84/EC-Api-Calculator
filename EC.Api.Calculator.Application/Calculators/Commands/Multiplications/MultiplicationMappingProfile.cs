using AutoMapper;
using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Application.Calculators.Commands.Multiplications
{
    public class SquareRootMappingProfile : Profile
    {
        public SquareRootMappingProfile()
        {
            CreateMap<Multiplication, MultiplicationCommandResponse>();
        }
    }
}
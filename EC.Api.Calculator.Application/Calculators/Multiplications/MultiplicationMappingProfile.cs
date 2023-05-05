using AutoMapper;
using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Application.Calculators.Multiplications
{
    public class SquareRootMappingProfile : Profile
    {
        public SquareRootMappingProfile()
        {
            CreateMap<Multiplication, MultiplicationCommandResponse>();
        }
    }
}
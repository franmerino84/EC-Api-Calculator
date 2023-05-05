using AutoMapper;
using EC.Api.Calculator.Application.Calculators.SquareRoots;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.SquareRoots
{
    public class CalculatorSquareRootMappingProfile : Profile
    {
        public CalculatorSquareRootMappingProfile()
        {
            CreateMap<SquareRootCommandResponse, CalculatorSquareRootResponseDto>();
        }
    }
}

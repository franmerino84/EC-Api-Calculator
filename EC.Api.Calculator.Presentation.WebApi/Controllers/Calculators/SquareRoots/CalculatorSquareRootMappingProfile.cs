using AutoMapper;
using EC.Api.Calculator.Application.Calculators.SquareRoots;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.SquareRoots.Dtos;

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

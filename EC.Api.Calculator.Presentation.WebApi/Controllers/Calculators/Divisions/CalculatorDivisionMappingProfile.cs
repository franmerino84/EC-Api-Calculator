using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Commands.Divisions;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Divisions.Dtos;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Divisions
{
    public class CalculatorDivisionMappingProfile : Profile
    {
        public CalculatorDivisionMappingProfile()
        {
            CreateMap<DivisionCommandResponse, CalculatorDivisionResponseDto>();
        }
    }
}

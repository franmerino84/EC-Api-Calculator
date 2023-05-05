using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Divisions;

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

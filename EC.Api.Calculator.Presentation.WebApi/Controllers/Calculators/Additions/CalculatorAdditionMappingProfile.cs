using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Additions;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Additions
{
    public class CalculatorAdditionMappingProfile : Profile
    {
        public CalculatorAdditionMappingProfile()
        {
            CreateMap<AdditionCommandResponse, CalculatorAdditionResponseDto>();
        }
    }
}

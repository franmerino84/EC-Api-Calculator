using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Additions;
using EC.Api.Calculator.Domain.ValueObjects.Operations;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Additions
{
    public class CalculatorAddResponseDtoMappingProfile : Profile
    {
        public CalculatorAddResponseDtoMappingProfile()
        {
            CreateMap<AdditionCommandResponse, CalculatorAddResponseDto>();
        }
    }
}

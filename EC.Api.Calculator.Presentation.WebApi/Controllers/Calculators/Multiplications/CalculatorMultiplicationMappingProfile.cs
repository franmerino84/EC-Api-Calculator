using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Multiplications;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Multiplications.Dtos;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Multiplications
{
    public class CalculatorMultiplicationMappingProfile : Profile
    {
        public CalculatorMultiplicationMappingProfile()
        {
            CreateMap<MultiplicationCommandResponse, CalculatorMultiplicationResponseDto>();
        }
    }
}

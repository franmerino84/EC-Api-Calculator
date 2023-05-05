using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Multiplications;

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

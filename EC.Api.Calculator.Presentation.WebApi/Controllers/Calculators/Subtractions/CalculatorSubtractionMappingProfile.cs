using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Subtractions;
using EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Subtractions.Dtos;

namespace EC.Api.Calculator.Presentation.WebApi.Controllers.Calculators.Subtractions
{
    public class CalculatorSubtractionMappingProfile : Profile
    {
        public CalculatorSubtractionMappingProfile()
        {
            CreateMap<SubtractionCommandResponse, CalculatorSubtractionResponseDto>();
        }
    }
}

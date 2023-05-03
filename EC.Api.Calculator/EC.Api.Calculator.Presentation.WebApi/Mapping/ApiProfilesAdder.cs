using AutoMapper;
using EC.Api.Calculator.Infrastructure.Mapping;
using EC.Api.Calculator.Presentation.WebApi.Controllers;

namespace EC.Api.Calculator.Presentation.WebApi.Mapping
{
    public static class ApiProfilesAdder
    {
        public static void AddApiProfiles(this IMapperConfigurationExpression mapperConfigurationExpression) =>
            mapperConfigurationExpression.AddProfilesFromAssemblyOfType<CalculatorController>();
    }
}

using AutoMapper;
using EC.Api.Calculator.Application.Calculators.Additions;
using EC.Api.Calculator.Infrastructure.Mapping;

namespace EC.Api.Calculator.Application.Mapping
{
    public static class ApplicationProfilesAdder
    {
        public static void AddApplicationProfiles(this IMapperConfigurationExpression mapperConfigurationExpression) =>
            mapperConfigurationExpression.AddProfilesFromAssemblyOfType<AdditionCommand>();
    }
}

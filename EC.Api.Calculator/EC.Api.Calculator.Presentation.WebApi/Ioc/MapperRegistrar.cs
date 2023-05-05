using AutoMapper;
using EC.Api.Calculator.Application.Mapping;
using EC.Api.Calculator.Presentation.WebApi.Mapping;

namespace EC.Api.Calculator.Presentation.WebApi.Ioc
{
    public static class MapperRegistrar
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            IMapper mapper = CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }

        private static IMapper CreateMapper()
        {
            MapperConfiguration mappingConfiguration = new(mc =>
            {
                mc.AddApiProfiles();
                mc.AddApplicationProfiles();
            });
            mappingConfiguration.AssertConfigurationIsValid();

            return mappingConfiguration.CreateMapper();
        }



    }
}
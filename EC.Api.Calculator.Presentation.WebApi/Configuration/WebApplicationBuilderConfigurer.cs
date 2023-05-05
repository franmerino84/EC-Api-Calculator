using EC.Api.Calculator.Presentation.WebApi.Ioc;

namespace EC.Api.Calculator.Presentation.WebApi.Configuration
{
    public static class WebApplicationBuilderConfigurer
    {
        public static WebApplicationBuilder GetConfiguredWebApplicationBuilder(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDependencies();

            builder.Services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            return builder;
        }
    }
}

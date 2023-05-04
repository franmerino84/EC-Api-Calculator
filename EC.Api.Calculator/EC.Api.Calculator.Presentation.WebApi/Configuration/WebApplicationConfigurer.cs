namespace EC.Api.Calculator.Presentation.WebApi.Configuration
{
    public static class WebApplicationConfigurer
    {
        public static WebApplication GetConfiguredWebApplication(string[] args) =>
            GetConfiguredWebApplication(WebApplicationBuilderConfigurer.GetConfiguredWebApplicationBuilder(args));

        public static WebApplication GetConfiguredWebApplication(WebApplicationBuilder builder)
        {
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }

    }
}

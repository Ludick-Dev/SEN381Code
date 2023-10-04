namespace CallCenter.Config
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Add your other services here

            // services.AddSingleton();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            
        }

    }
}


namespace CallCenter.Config
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
            services.AddSingleton(configuration);

            DatabaseConfig databaseConfig = new DatabaseConfig();

            configuration.Bind("Database", databaseConfig); 
            services.AddSingleton(databaseConfig);
            services.AddSingleton<DatabaseServices>();

            services.AddLogging();
            services.AddControllersWithViews();

            // Add your other services here

            // services.AddSingleton();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}


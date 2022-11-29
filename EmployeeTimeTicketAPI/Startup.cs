using EmployeeTimeTicketApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace EmployeeTimeTicketApp.UI
{
    public class Startup
    {
        private readonly ILoggerFactory? _loggerFactory;
        private readonly StreamWriter _logstream = new StreamWriter("ErrorLog.txt", append: true);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /* (OCP)This method gets called by the runtime. Use this method to add services to the container. this method is 
         * open to extention by adding more services. The parameter services is taken and can then extend the services 
         * to add controllers or loggers without modifying the methods for each concern. */
        public void ConfigureServices(IServiceCollection services)
        {
        

            services.AddControllersWithViews();
            services.AddDbContext<EmployeeTimeTicketContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DBConnectionString"))
              .UseLoggerFactory(_loggerFactory)
              .EnableSensitiveDataLogging()
              .LogTo(_logstream.WriteLine)
                 /*.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)*/);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmployeeTimeTicketAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeTimeTicketAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
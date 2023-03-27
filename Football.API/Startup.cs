using Football.Database;
using Football.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Football.API
{
    public class Startup
    {
        readonly IConfiguration Configuration;
        readonly string allowSpecificOrigins = "_AllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.AddDbContext<FootballContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            Bootstrapper.ConfigureServices(services);

            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var allowedOrigins = Configuration.GetValue<string>("AllowedOrigins");
            services.AddCors(options =>
            {
                options.AddPolicy(name: allowSpecificOrigins,
                                  builder =>
                                  {
                                      builder
                                        .WithOrigins(allowedOrigins.Split(";"))
                                        .AllowAnyMethod()
                                        .AllowCredentials()
                                        .AllowAnyHeader();
                                  });
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(allowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

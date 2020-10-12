using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Train.Api.Extensions;
using Train.Data;
using Train.Domain.Factories.Interfaces;
using Train.Services.Factories;
using Train.Services.Factories.Interfaces;

namespace Train.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.WithMediatR();

            services.AddDbContext<TrainContext>(opt =>
               opt.UseInMemoryDatabase("TrainDb").UseLazyLoadingProxies());

            services.AddScoped<IWorkoutFactory, WorkoutFactory>();
            services.AddScoped<IWorkoutExercisesFactory, WorkoutExercisesFactory>();

            services
                .AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

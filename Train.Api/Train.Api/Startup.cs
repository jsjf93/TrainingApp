using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Train.Data;
using Train.Domain.Factories.Interfaces;
using Train.Services.CommandHandlers;
using Train.Services.CommandHandlers.Interfaces;
using Train.Services.Factories;
using Train.Services.QueryProcessors;
using Train.Services.QueryProcessors.Interfaces;

namespace Train.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TrainContext>(opt =>
               opt.UseInMemoryDatabase("TrainDb"));

            services.AddScoped<IWorkoutFactory, WorkoutFactory>();

            services.AddScoped<IGetExercisesQueryProcessor, GetExercisesQueryProcessor>();
            services.AddScoped<ICreateWorkoutCommandHandler, CreateWorkoutCommandHandler>();

            services
                .AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

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
using Train.Services.Commands;
using Train.Services.Factories;
using Train.Services.Factories.Interfaces;
using Train.Services.Utils;

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
            services.AddDbContext<TrainContext>(opt =>
               opt.UseInMemoryDatabase("TrainDb").UseLazyLoadingProxies());

            services.AddScoped<IWorkoutFactory, WorkoutFactory>();
            services.AddScoped<IWorkoutExercisesFactory, WorkoutExercisesFactory>();

            services.AddScoped<Messages>();

            services.AddTransient<ICommandHandler<CreateWorkoutCommand>, CreateWorkoutCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateWorkoutCommand>, UpdateWorkoutCommandHandler>();

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

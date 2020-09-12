using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Train.Api.Controllers.Requests;
using Train.Domain.Models;
using Train.Services.CommandHandlers.Interfaces;
using Train.Services.Commands;

namespace Train.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly ICreateWorkoutCommandHandler<CreateWorkoutCommand> handler;

        public WorkoutsController(ICreateWorkoutCommandHandler<CreateWorkoutCommand> handler)
        {
            this.handler = handler;
        }

        [HttpPost]
        public Workout CreateWorkout([FromBody] JObject jObject)
        {
            CreateWorkoutRequest request = JsonConvert.DeserializeObject<CreateWorkoutRequest>(jObject.ToString());

            var command = new CreateWorkoutCommand()
            {
                WorkoutName = request.WorkoutName,
                WorkoutExercises = request.WorkoutExercises
            };

            var result = this.handler.Execute(command);

            return result;
        }
    }
}
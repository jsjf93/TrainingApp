using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Train.Api.Controllers.Requests;
using Train.Services.CommandHandlers.Interfaces;
using Train.Services.Commands;
using Train.Services.Utils;

namespace Train.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly Messages messages;

        public WorkoutsController(Messages messages)
        {
            this.messages = messages;
        }

        [HttpPost]
        public IActionResult CreateWorkout([FromBody] JObject jObject)
        {
            var request = JsonConvert.DeserializeObject<CreateWorkoutRequest>(jObject.ToString());

            var command = new CreateWorkoutCommand()
            {
                WorkoutName = request.WorkoutName,
                WorkoutExercises = request.WorkoutExercises
            };

            messages.Dispatch(command);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateWorkout([FromBody] JObject jObject)
        {
            var request = JsonConvert.DeserializeObject<UpdateWorkoutRequest>(jObject.ToString());

            var command = new UpdateWorkoutCommand()
            {
                Id = request.Id,
                WorkoutName = request.WorkoutName,
                WorkoutExercises = request.WorkoutExercises
            };

            messages.Dispatch(command);

            return Ok();
        }
    }
}
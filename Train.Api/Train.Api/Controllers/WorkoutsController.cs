using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Train.Api.Controllers.Requests;
using Train.Services.Commands;

namespace Train.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IMediator mediator;

        public WorkoutsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkout([FromBody] JObject jObject)
        {
            var request = JsonConvert.DeserializeObject<CreateWorkoutRequest>(jObject.ToString());

            var command = new CreateWorkoutCommand()
            {
                WorkoutName = request.WorkoutName,
                WorkoutExercises = request.WorkoutExercises
            };

            // Todo: change guid result to proper response object
            var result = await this.mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkout([FromBody] JObject jObject)
        {
            var request = JsonConvert.DeserializeObject<UpdateWorkoutRequest>(jObject.ToString());

            var command = new UpdateWorkoutCommand()
            {
                Id = request.Id,
                WorkoutName = request.WorkoutName,
                WorkoutExercises = request.WorkoutExercises
            };

            await this.mediator.Send(command);

            return Ok();
        }
    }
}
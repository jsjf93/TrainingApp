using Newtonsoft.Json.Linq;

namespace Train.Api.Controllers.Requests
{
    public class CreateWorkoutRequest
    {
        public string WorkoutName { get; set; }

        public JArray WorkoutExercises { get; set; }
    }
}

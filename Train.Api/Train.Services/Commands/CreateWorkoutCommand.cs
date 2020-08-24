using Newtonsoft.Json.Linq;

namespace Train.Services.Commands
{
    public class CreateWorkoutCommand
    {
        public string WorkoutName { get; set; }

        public JArray WorkoutExercises { get; set; }
    }
}

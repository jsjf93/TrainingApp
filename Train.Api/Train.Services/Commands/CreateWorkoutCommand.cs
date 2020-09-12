using Newtonsoft.Json.Linq;
using Train.Services.Commands.Interfaces;

namespace Train.Services.Commands
{
    public class CreateWorkoutCommand : ICommand
    {
        public string WorkoutName { get; set; }

        public JArray WorkoutExercises { get; set; }
    }
}

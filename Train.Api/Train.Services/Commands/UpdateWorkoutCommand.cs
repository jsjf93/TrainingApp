using System;
using Newtonsoft.Json.Linq;
using Train.Services.Commands.Interfaces;

namespace Train.Services.Commands
{
    public class UpdateWorkoutCommand : ICommand
    {
        public Guid Id { get; set; }

        public string WorkoutName { get; set; }

        public JArray WorkoutExercises { get; set; }
    }
}

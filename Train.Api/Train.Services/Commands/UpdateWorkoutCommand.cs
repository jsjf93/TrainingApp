using System;
using MediatR;
using Newtonsoft.Json.Linq;

namespace Train.Services.Commands
{
    public class UpdateWorkoutCommand : IRequest
    {
        public Guid Id { get; set; }

        public string WorkoutName { get; set; }

        public JArray WorkoutExercises { get; set; }
    }
}

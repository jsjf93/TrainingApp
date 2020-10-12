using System;
using MediatR;
using Newtonsoft.Json.Linq;

namespace Train.Services.Commands
{
    public sealed class CreateWorkoutCommand : IRequest<Guid>
    {
        public string WorkoutName { get; set; }

        public JArray WorkoutExercises { get; set; }
    }
}

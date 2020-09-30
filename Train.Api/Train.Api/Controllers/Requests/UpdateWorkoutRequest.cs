using System;
using Newtonsoft.Json.Linq;

namespace Train.Api.Controllers.Requests
{
    public class UpdateWorkoutRequest
    {
        public Guid Id { get; set; }

        public string WorkoutName { get; set; }

        public JArray WorkoutExercises { get; set; }
    }
}

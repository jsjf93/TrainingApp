using System.Collections.Generic;
using Newtonsoft.Json;
using Train.Domain.Converters;
using Train.Domain.Models;
using Train.Services.Commands;

namespace Train.Services.Factories.Interfaces
{
    public class WorkoutExercisesFactory : IWorkoutExercisesFactory
    {
        public IEnumerable<WorkoutExercise> Create(UpdateWorkoutCommand command)
        {
            JsonConverter[] converters = { new ExerciseSetConverter() };
            var workoutExercises = JsonConvert.DeserializeObject<IEnumerable<WorkoutExercise>>(command.WorkoutExercises.ToString(), new JsonSerializerSettings()
            {
                Converters = converters
            });

            return workoutExercises;
        }
    }
}

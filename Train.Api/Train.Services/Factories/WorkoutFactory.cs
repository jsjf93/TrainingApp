using System.Collections.Generic;
using Newtonsoft.Json;
using Train.Domain.Converters;
using Train.Domain.Factories.Interfaces;
using Train.Domain.Models;
using Train.Services.Commands;

namespace Train.Services.Factories
{
    public class WorkoutFactory : IWorkoutFactory
    {
        public Workout Create(CreateWorkoutCommand command)
        {
            JsonConverter[] converters = { new ExerciseSetConverter() };
            var workoutExercises = JsonConvert.DeserializeObject<IEnumerable<WorkoutExercise>>(command.WorkoutExercises.ToString(), new JsonSerializerSettings()
            {
                Converters = converters
            });

            var workout = new Workout(command.WorkoutName, workoutExercises);

            return workout;
        }
    }
}

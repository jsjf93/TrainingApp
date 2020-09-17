using System;
using System.Text.Json.Serialization;
using Train.Domain.Converters;
using Train.Domain.Models.Enums;

namespace Train.Domain.Models.Sets.Base
{
    [JsonConverter(typeof(ExerciseSetConverter))]
    public abstract class ExerciseSet : Entity
    {
        public ExerciseSet()
        {
        }

        public ExerciseSet(ExerciseType exerciseType, int order)
        {
            this.ExerciseType = exerciseType;
            this.Order = new Order(order);
        }

        public ExerciseType ExerciseType { get; private set; }

        public virtual Order Order { get; private set; }

        public virtual WorkoutExercise WorkoutExercise { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using Train.Domain.Models.Enums;
using Train.Domain.Models.Sets.Base;

namespace Train.Domain.Models
{
    public class WorkoutExercise : Entity
    {
        protected WorkoutExercise()
        {
        }

        public WorkoutExercise(string exerciseName, ExerciseType exerciseType, IEnumerable<ExerciseSet> exerciseSets, int order)
        {
            if (string.IsNullOrEmpty(exerciseName))
            {
                throw new ArgumentException();
            }

            this.ExerciseName = exerciseName;
            this.ExerciseType = exerciseType;
            this.ExerciseSets = exerciseSets;
            this.Order = new Order(order);
        }
    
        public string ExerciseName { get; private set; }

        public ExerciseType ExerciseType { get; private set; }

        public IEnumerable<ExerciseSet> ExerciseSets { get; private set; }

        public Order Order { get; private set; }

        public virtual Guid WorkoutId { get; private set; }
    }
}

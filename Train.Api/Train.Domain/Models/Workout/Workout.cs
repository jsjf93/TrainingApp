using System;
using System.Collections.Generic;

namespace Train.Domain.Models
{
    public class Workout : AggregateRoot
    {
        protected Workout()
        {
        }

        public Workout(string workoutName, IEnumerable<WorkoutExercise> workoutExercises)
        {
            if (string.IsNullOrEmpty(workoutName)) {
                throw new ArgumentException();
            }

            this.WorkoutName = workoutName;
            this.WorkoutExercises = workoutExercises;
        }

        public string WorkoutName { get; private set; }

        public virtual IEnumerable<WorkoutExercise> WorkoutExercises { get; private set; }

        public virtual void Update(string name, IEnumerable<WorkoutExercise> workoutExercises)
        {
            this.WorkoutName = name;
            this.WorkoutExercises = workoutExercises;
        }
    }
}

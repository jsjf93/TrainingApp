using System;
using System.Collections.Generic;
using System.Text;

namespace Train.Domain
{
    public class Exercise : Entity
    {
        public Exercise()
        {
        }

        public Exercise(string exerciseName)
        {
            if (string.IsNullOrEmpty(exerciseName))
            {
                throw new ArgumentException();
            }

            this.ExerciseName = exerciseName;
        }

        public string ExerciseName { get; private set; }

        public void UpdateExerciseName(string exerciseName)
        {
            if (string.IsNullOrEmpty(exerciseName))
            {
                throw new ArgumentException();
            }

            this.ExerciseName = exerciseName;
        }
    }
}

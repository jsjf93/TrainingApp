using System;
using Train.Domain.Models.Enums;
using Train.Domain.Models.Sets.Base;

namespace Train.Domain.Models.Sets
{
    public class IntervalSet : ExerciseSet
    {
        protected IntervalSet() : base()
        {
        }

        public IntervalSet(ExerciseType exerciseType, int order) : base(exerciseType, order)
        {
        }

        public double Weight { get; private set; }

        public TimeSpan ExerciseDuration { get; set; }

        public TimeSpan RestDuration { get; set; }
    }
}

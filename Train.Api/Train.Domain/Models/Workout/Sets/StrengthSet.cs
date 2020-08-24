using System;
using Train.Domain.Models.Enums;
using Train.Domain.Models.Sets.Base;

namespace Train.Domain.Models.Sets
{
    public class StrengthSet : ExerciseSet
    {
        protected StrengthSet() : base()
        {
        }

        public StrengthSet(ExerciseType exerciseType, int order) : base(exerciseType, order)
        {
        }

        public int Reps { get; private set; }

        public double Weight { get; private set; }

        public TimeSpan RestDuration { get; private set; }

    }
}

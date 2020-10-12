using System;
using Train.Domain.Models.Enums;
using Train.Domain.Models.Sets.Base;

namespace Train.Domain.Models.Sets
{
    public class DurationSet : ExerciseSet
    {
        protected DurationSet() : base()
        {
        }

        public DurationSet(ExerciseType exerciseType, int order) : base(exerciseType, order)
        {
        }

        public TimeSpan Duration { get; set; }
    }
}

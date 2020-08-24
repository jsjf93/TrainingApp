using System.Collections.Generic;
using System.Linq;
using Train.Data;
using Train.Domain;
using Train.Services.QueryProcessors.Interfaces;

namespace Train.Services.QueryProcessors
{
    public class GetExercisesQueryProcessor : IGetExercisesQueryProcessor
    {
        private readonly TrainContext context;

        public GetExercisesQueryProcessor(TrainContext context)
        {
            this.context = context;
        }

        public List<Exercise> Process()
        {
            return this.context.Exercises.ToList();
        }
    }
}

using System.Collections.Generic;
using Train.Domain;

namespace Train.Services.QueryProcessors.Interfaces
{
    public interface IGetExercisesQueryProcessor
    {
        List<Exercise> Process();
    }
}

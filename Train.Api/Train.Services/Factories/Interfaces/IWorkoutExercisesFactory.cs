using System.Collections.Generic;
using Train.Domain.Models;
using Train.Services.Commands;

namespace Train.Services.Factories.Interfaces
{
    public interface IWorkoutExercisesFactory
    {
        IEnumerable<WorkoutExercise> Create(UpdateWorkoutCommand command);
    }
}

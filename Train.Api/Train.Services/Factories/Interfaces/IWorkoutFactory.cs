using Train.Domain.Models;
using Train.Services.Commands;

namespace Train.Domain.Factories.Interfaces
{
    public interface IWorkoutFactory
    {
        Workout Create(CreateWorkoutCommand command);
    }
}

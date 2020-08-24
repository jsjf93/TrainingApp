using Train.Domain.Models;
using Train.Services.Commands;

namespace Train.Services.CommandHandlers.Interfaces
{
    public interface ICreateWorkoutCommandHandler
    {
        Workout Execute(CreateWorkoutCommand command);
    }
}

using Train.Domain.Models;
using Train.Services.Commands;
using Train.Services.Commands.Interfaces;

namespace Train.Services.CommandHandlers.Interfaces
{
    public interface ICreateWorkoutCommandHandler<T> where T : ICommand
    {
        Workout Execute(CreateWorkoutCommand command);
    }
}

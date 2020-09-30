using Train.Services.Commands.Interfaces;

namespace Train.Services.CommandHandlers.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}

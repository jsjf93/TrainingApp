using Train.Data;
using Train.Domain.Factories.Interfaces;
using Train.Services.CommandHandlers.Interfaces;
using Train.Services.Commands;

namespace Train.Services.CommandHandlers
{
    public sealed class CreateWorkoutCommandHandler : ICommandHandler<CreateWorkoutCommand>
    {
        private readonly TrainContext context;

        private readonly IWorkoutFactory factory;

        public CreateWorkoutCommandHandler(TrainContext context, IWorkoutFactory factory)
        {
            this.context = context;
            this.factory = factory;
        }

        public void Execute(CreateWorkoutCommand command)
        {
            var workout = this.factory.Create(command);

            this.context.Workouts.Add(workout);
            this.context.SaveChanges();
        }
    }
}

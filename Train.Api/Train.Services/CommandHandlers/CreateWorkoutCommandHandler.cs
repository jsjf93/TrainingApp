using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Train.Data;
using Train.Domain.Factories.Interfaces;
using Train.Services.Commands;

namespace Train.Services.CommandHandlers
{
    public sealed class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand, Guid>
    {
        private readonly TrainContext context;

        private readonly IWorkoutFactory factory;

        public CreateWorkoutCommandHandler(TrainContext context, IWorkoutFactory factory)
        {
            this.context = context;
            this.factory = factory;
        }

        public Task<Guid> Handle(CreateWorkoutCommand command, CancellationToken cancellationToken)
        {
            var workout = this.factory.Create(command);

            this.context.Workouts.Add(workout);
            this.context.SaveChanges();

            return Task.FromResult(workout.Id);
        }
    }
}

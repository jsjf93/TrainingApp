using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Train.Data;
using Train.Services.Commands;

namespace Train.Services.CommandHandlers
{
    public class DeleteWorkoutCommandHandler : IRequestHandler<DeleteWorkoutCommand>
    {
        private readonly TrainContext context;

        public DeleteWorkoutCommandHandler(TrainContext context)
        {
            this.context = context;
        }

        public Task<Unit> Handle(DeleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = this.context.Workouts.Find(request.WorkoutId);

            if (workout != null)
            {
                this.context.Workouts.Remove(workout);
                this.context.SaveChanges();
            }

            return Task.FromResult(Unit.Value);
        }
    }
}

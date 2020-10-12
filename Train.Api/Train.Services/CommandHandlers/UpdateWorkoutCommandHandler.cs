using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Train.Data;
using Train.Services.Commands;
using Train.Services.Factories.Interfaces;

namespace Train.Services.CommandHandlers
{
    public sealed class UpdateWorkoutCommandHandler : IRequestHandler<UpdateWorkoutCommand>
    {
        private readonly TrainContext context;
        private readonly IWorkoutExercisesFactory factory;

        public UpdateWorkoutCommandHandler(TrainContext context, IWorkoutExercisesFactory factory)
        {
            this.context = context;
            this.factory = factory;
        }

        public Task<Unit> Handle(UpdateWorkoutCommand command, CancellationToken cancellationToken)
        {
            var workoutExercises = this.factory.Create(command);
            var workout = this.context.Workouts
                .Include(p => p.WorkoutExercises)
                .ThenInclude(p => p.ExerciseSets)
                .SingleOrDefault(p => p.Id == command.Id);

            if (workout != null)
            {
                workout.Update(command.WorkoutName, workoutExercises);
                this.context.SaveChanges();
            }

            return Task.FromResult(Unit.Value);
        }
    }
}

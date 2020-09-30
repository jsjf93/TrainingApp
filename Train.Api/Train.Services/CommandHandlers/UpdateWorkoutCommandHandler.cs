using System.Linq;
using Microsoft.EntityFrameworkCore;
using Train.Data;
using Train.Services.CommandHandlers.Interfaces;
using Train.Services.Commands;
using Train.Services.Factories.Interfaces;

namespace Train.Services.CommandHandlers
{
    public sealed class UpdateWorkoutCommandHandler : ICommandHandler<UpdateWorkoutCommand>
    {
        private readonly TrainContext context;
        private readonly IWorkoutExercisesFactory factory;

        public UpdateWorkoutCommandHandler(TrainContext context, IWorkoutExercisesFactory factory)
        {
            this.context = context;
            this.factory = factory;
        }

        public void Execute(UpdateWorkoutCommand command)
        {
            var workoutExercises = this.factory.Create(command);
            var workout = this.context.Workouts
                .Include(p => p.WorkoutExercises)
                .ThenInclude(p => p.ExerciseSets)
                .SingleOrDefault(p => p.Id == command.Id);

            if (workout != null)
            {
                workout.SetWorkoutExercises(workoutExercises);
                this.context.SaveChanges();
            }
        }
    }
}

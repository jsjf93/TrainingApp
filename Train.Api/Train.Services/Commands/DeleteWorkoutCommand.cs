using System;
using MediatR;

namespace Train.Services.Commands
{
    public class DeleteWorkoutCommand : IRequest
    {
        public Guid WorkoutId { get; set; }
    }
}

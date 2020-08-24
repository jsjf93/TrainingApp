using System;
using FluentAssertions;
using Train.Domain;
using Xunit;

namespace Train.Test
{
    public class ExerciseTests
    {
        [Fact]
        public void WhenUpdateNameIsCalled_WithAValidString_ItUpdatesTheExerciseName()
        {
            var name = "Pushup";
            var exercise = new Exercise(name);

            exercise.UpdateExerciseName(name);

            exercise.ExerciseName.Should().Be(name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void WhenUpdateNameIsCalled_WithAnInvalidString_ItShouldThrowAnException(string name)
        {
            var exercise = new Exercise();

            Action act = () => exercise.UpdateExerciseName(name);

            act.Should().Throw<ArgumentException>();
        }
    }
}

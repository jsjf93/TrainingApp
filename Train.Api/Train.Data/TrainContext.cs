using System;
using Microsoft.EntityFrameworkCore;
using Train.Domain;
using Train.Domain.Models;
using Train.Domain.Models.Enums;
using Train.Domain.Models.Sets;
using Train.Domain.Models.Sets.Base;

namespace Train.Data
{
    public class TrainContext : DbContext
    {
        public TrainContext(DbContextOptions<TrainContext> options)
            : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

        public DbSet<ExerciseSet> ExerciseSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseSet>()
              .HasDiscriminator(p => p.ExerciseType)
              .HasValue<StrengthSet>(ExerciseType.Strength)
              .HasValue<DurationSet>(ExerciseType.Duration)
              .HasValue<IntervalSet>(ExerciseType.Interval);

            modelBuilder.Entity<ExerciseSet>()
              .OwnsOne(o => o.Order)
              .Property(p => p.Value)
              .HasColumnName("Order");

            modelBuilder.Entity<ExerciseSet>()
              .Property(p => p.Id)
              .ValueGeneratedNever();

            modelBuilder.Entity<WorkoutExercise>()
              .OwnsOne(o => o.Order)
              .Property(p => p.Value)
              .HasColumnName("Order");

            modelBuilder.Entity<WorkoutExercise>()
              .Property(p => p.Id)
              .ValueGeneratedNever();
        }
    }
}

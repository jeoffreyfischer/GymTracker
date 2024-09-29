using GymTracker.Models;
using Microsoft.EntityFrameworkCore;

public class GymContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<TrackingEntry> TrackingEntries { get; set; }

    public GymContext(DbContextOptions<GymContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>().HasData(
            new Exercise { Id = 1, Name = "Bench Press" },
            new Exercise { Id = 2, Name = "Barbell Squat" },
            new Exercise { Id = 3, Name = "Barbell Deadlift" }
        );

        modelBuilder.Entity<TrackingEntry>().HasData(
            new TrackingEntry { Id = 1, Date = DateTime.Now, LoadInKg = 80, Reps = 10, Sets = 3, ExerciseId = 1 },
            new TrackingEntry { Id = 2, Date = DateTime.Now, LoadInKg = 100, Reps = 8, Sets = 3, ExerciseId = 2 },
            new TrackingEntry { Id = 3, Date = DateTime.Now, LoadInKg = 120, Reps = 5, Sets = 3, ExerciseId = 3 }
        );
    }
}

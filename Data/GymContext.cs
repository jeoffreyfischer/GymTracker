using GymTracker2.Models;
using Microsoft.EntityFrameworkCore;

public class GymContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<TrackingEntry> TrackingEntries { get; set; }

    public GymContext(DbContextOptions<GymContext> options) : base(options) { }
}

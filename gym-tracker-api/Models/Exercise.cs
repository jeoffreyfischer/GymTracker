namespace GymTracker.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<TrackingEntry>? TrackingEntries { get; set; }
    }
}

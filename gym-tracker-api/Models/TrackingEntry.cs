namespace GymTracker.Models
{
    public class TrackingEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int LoadInKg { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
    }

}

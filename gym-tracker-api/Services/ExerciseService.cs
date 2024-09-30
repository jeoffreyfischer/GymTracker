using GymTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.Services;

public class ExerciseService
{
    private readonly GymContext _context;

    public ExerciseService(GymContext context)
    {
        _context = context;
    }

    // Get all tracking exercises
    public async Task<List<Exercise>> GetExercisesAsync()
    {
        return await _context.Exercises.ToListAsync();
    }

    // Get an exercise by ID
    public async Task<Exercise?> GetExerciseByIdAsync(int id)
    {
        return await _context.Exercises.FindAsync(id);
    }

    // Create a new exercise
    public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
    {
        if (exercise == null)
        {
            throw new ArgumentNullException(nameof(exercise), "Exercise cannot be null.");
        }

        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();
        return exercise;
    }

    // Update an existing exercise
    public async Task UpdateExerciseAsync(Exercise exercise)
    {
        _context.Entry(exercise).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    // Delete an exercise by ID
    public async Task DeleteExerciseAsync(Exercise exercise)
    {
        _context.Exercises.Remove(exercise);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExerciseExistsAsync(int id)
    {
        return await _context.Exercises.AnyAsync(e => e.Id == id);
    }
}

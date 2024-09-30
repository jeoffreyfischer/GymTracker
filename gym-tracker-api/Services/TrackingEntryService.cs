using GymTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.Services;

public class TrackingEntryService
{
    private readonly GymContext _context;

    public TrackingEntryService(GymContext context)
    {
        _context = context;
    }

    // Get all tracking entries
    public async Task<IEnumerable<TrackingEntry>> GetTrackingEntriesAsync()
    {
        return await _context.TrackingEntries.Include(te => te.Exercise).ToListAsync();
    }

    // Get a tracking entry by ID
    public async Task<TrackingEntry?> GetTrackingEntryByIdAsync(int id)
    {
        return await _context.TrackingEntries.Include(te => te.Exercise).FirstOrDefaultAsync(te => te.Id == id);
    }

    // Create a new tracking entry
    public async Task<TrackingEntry> CreateTrackingEntryAsync(TrackingEntry trackingEntry)
    {
        _context.TrackingEntries.Add(trackingEntry);
        await _context.SaveChangesAsync();
        return trackingEntry;
    }

    // Update an existing tracking entry
    public async Task UpdateTrackingEntryAsync(TrackingEntry trackingEntry)
    {
        _context.Entry(trackingEntry).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    // Delete a tracking entry by ID
    public async Task<bool> DeleteTrackingEntryAsync(int id)
    {
        var trackingEntry = await _context.TrackingEntries.FindAsync(id);
        if (trackingEntry == null)
        {
            return false;
        }

        _context.TrackingEntries.Remove(trackingEntry);
        await _context.SaveChangesAsync();
        return true;
    }
}

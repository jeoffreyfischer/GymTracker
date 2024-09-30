using GymTracker.Models;
using GymTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class TrackingEntriesController : ControllerBase
{
    private readonly TrackingEntryService _trackingEntryService;
    private readonly ILogger<TrackingEntriesController> _logger;

    public TrackingEntriesController(TrackingEntryService trackingEntryService, ILogger<TrackingEntriesController> logger)
    {
        _trackingEntryService = trackingEntryService;
        _logger = logger;
    }

    // GET: /trackingentries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrackingEntry>>> GetTrackingEntries()
    {
        return Ok(await _trackingEntryService.GetTrackingEntriesAsync());
    }

    // GET: /trackingentries/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<TrackingEntry>> GetTrackingEntry(int id)
    {
        var trackingEntry = await _trackingEntryService.GetTrackingEntryByIdAsync(id);
        if (trackingEntry == null)
        {
            return NotFound();
        }

        return Ok(trackingEntry);
    }

    // POST: /trackingentries
    [HttpPost]
    public async Task<ActionResult<TrackingEntry>> CreateTrackingEntry(TrackingEntry trackingEntry)
    {
        if (trackingEntry == null)
        {
            return BadRequest("TrackingEntry cannot be null.");
        }

        var createdEntry = await _trackingEntryService.CreateTrackingEntryAsync(trackingEntry);
        return CreatedAtAction(nameof(GetTrackingEntry), new { id = createdEntry.Id }, createdEntry);
    }

    // PUT: /trackingentries/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTrackingEntry(int id, TrackingEntry trackingEntry)
    {
        if (id != trackingEntry.Id)
        {
            return BadRequest("TrackingEntry ID mismatch.");
        }

        try
        {
            await _trackingEntryService.UpdateTrackingEntryAsync(trackingEntry);
        }
        catch (DbUpdateConcurrencyException)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: /trackingentries/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrackingEntry(int id)
    {
        var deleted = await _trackingEntryService.DeleteTrackingEntryAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}

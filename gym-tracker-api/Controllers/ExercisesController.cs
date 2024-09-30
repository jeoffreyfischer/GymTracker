using GymTracker.Models;
using GymTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.Controllers;

[ApiController]
[Route("[controller]")]
public class ExercisesController : ControllerBase
{
    private readonly ExerciseService _exerciseService;
    private readonly ILogger<ExercisesController> _logger;

    public ExercisesController(ExerciseService exerciseService, ILogger<ExercisesController> logger)
    {
        _exerciseService = exerciseService;
        _logger = logger;
    }

    // GET: /exercises
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
    {
        return await _exerciseService.GetExercisesAsync();
    }

    // GET: /exercises/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Exercise>> GetExercise(int id)
    {
        var exercise = await _exerciseService.GetExerciseByIdAsync(id);
        if (exercise == null)
        {
            return NotFound();
        }
        return Ok(exercise);
    }

    // POST: /exercises
    [HttpPost]
    public async Task<ActionResult<Exercise>> CreateExercise(Exercise exercise)
    {
        try
        {
            var createdExercise = await _exerciseService.CreateExerciseAsync(exercise);
            return CreatedAtAction(nameof(GetExercises), new { id = createdExercise.Id }, createdExercise);
        }
        catch (ArgumentNullException ex)
        {
            _logger.LogError(ex, "Error creating exercise.");
            return BadRequest(ex.Message);
        }
    }

    // PUT: /exercises/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExercise(int id, Exercise exercise)
    {
        if (id != exercise.Id)
        {
            return BadRequest("Exercise ID mismatch.");
        }

        var existingExercise = await _exerciseService.GetExerciseByIdAsync(id);
        if (existingExercise == null)
        {
            return NotFound();
        }

        existingExercise.Name = exercise.Name;

        try
        {
            await _exerciseService.UpdateExerciseAsync(existingExercise);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _exerciseService.ExerciseExistsAsync(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // DELETE: /exercises/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExercise(int id)
    {
        var exercise = await _exerciseService.GetExerciseByIdAsync(id);
        if (exercise == null)
        {
            return NotFound();
        }

        await _exerciseService.DeleteExerciseAsync(exercise);
        return NoContent();
    }
}

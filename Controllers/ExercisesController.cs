using GymTracker2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymTracker2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly GymContext _context;
        private readonly ILogger<ExercisesController> _logger;

        public ExercisesController(GymContext context, ILogger<ExercisesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            return await _context.Exercises.ToListAsync();
        }

        // POST: /exercises
        [HttpPost]
        public async Task<ActionResult<Exercise>> CreateExercise(Exercise exercise)
        {
            if (exercise == null)
            {
                return BadRequest("Exercise cannot be null.");
            }

            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExercises), new { id = exercise.Id }, exercise);
        }

        // PUT: /exercises/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExercise(int id, Exercise exercise)
        {
            if (id != exercise.Id)
            {
                return BadRequest("Exercise ID mismatch.");
            }

            var existingExercise = await _context.Exercises.FindAsync(id);
            if (existingExercise == null)
            {
                return NotFound();
            }

            existingExercise.Name = exercise.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercises.Any(e => e.Id == id);
        }

        // DELETE: /exercises/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

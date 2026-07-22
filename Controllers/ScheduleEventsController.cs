using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaseSchedule.Data;
using BaseSchedule.Models;

namespace BaseSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleEventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ScheduleEventsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleEvent>>> GetScheduleEvents()
        {
            return await _context.ScheduleEvents.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ScheduleEvent>> PostScheduleEvent(ScheduleEvent scheduleEvent)
        {
            _context.ScheduleEvents.Add(scheduleEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetScheduleEvents), new { id = scheduleEvent.Id }, scheduleEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleEvent(int id, ScheduleEvent scheduleEvent)
        {
            if (id != scheduleEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(scheduleEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleEventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleEvent(int id)
        {
            var scheduleEvent = await _context.ScheduleEvents.FindAsync(id);
            if (scheduleEvent == null)
            {
                return NotFound();
            }

            _context.ScheduleEvents.Remove(scheduleEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleEventExists(int id)
        {
            return _context.ScheduleEvents.Any(e => e.Id == id);
        }
    }
}

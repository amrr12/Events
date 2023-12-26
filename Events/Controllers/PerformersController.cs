using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Events.Models;
using LibraryAPI.Models;

namespace Events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformersController : ControllerBase
    {
        private readonly LibraryDbContext _context;

        public PerformersController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: api/Performers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Performer>>> GetPerformsers()
        {
          if (_context.Performsers == null)
          {
              return NotFound();
          }
            return await _context.Performsers.ToListAsync();
        }

        // GET: api/Performers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Performer>> GetPerformer(int id)
        {
          if (_context.Performsers == null)
          {
              return NotFound();
          }
            var performer = await _context.Performsers.FindAsync(id);

            if (performer == null)
            {
                return NotFound();
            }

            return performer;
        }

        // PUT: api/Performers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerformer(int id, Performer performer)
        {
            if (id != performer.Id)
            {
                return BadRequest();
            }

            _context.Entry(performer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerformerExists(id))
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

        // POST: api/Performers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Performer>> PostPerformer(Performer performer)
        {
          if (_context.Performsers == null)
          {
              return Problem("Entity set 'LibraryDbContext.Performsers'  is null.");
          }
            _context.Performsers.Add(performer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerformer", new { id = performer.Id }, performer);
        }

        // DELETE: api/Performers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformer(int id)
        {
            if (_context.Performsers == null)
            {
                return NotFound();
            }
            var performer = await _context.Performsers.FindAsync(id);
            if (performer == null)
            {
                return NotFound();
            }

            _context.Performsers.Remove(performer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PerformerExists(int id)
        {
            return (_context.Performsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

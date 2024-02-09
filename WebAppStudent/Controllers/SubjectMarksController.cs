using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppStudent.Data;
using WebAppStudent.Models;

namespace WebAppStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectMarksController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public SubjectMarksController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: api/SubjectMarks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectMarks>>> GetSubjectMarks()
        {
          if (_context.SubjectMarks == null)
          {
              return NotFound();
          }
            return await _context.SubjectMarks.ToListAsync();
        }

        // GET: api/SubjectMarks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectMarks>> GetSubjectMarks(int id)
        {
          if (_context.SubjectMarks == null)
          {
              return NotFound();
          }
            var subjectMarks = await _context.SubjectMarks.FindAsync(id);

            if (subjectMarks == null)
            {
                return NotFound();
            }

            return subjectMarks;
        }

        // PUT: api/SubjectMarks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectMarks(int id, SubjectMarks subjectMarks)
        {
            if (id != subjectMarks.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectMarks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectMarksExists(id))
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

        // POST: api/SubjectMarks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectMarks>> PostSubjectMarks(SubjectMarks subjectMarks)
        {
          if (_context.SubjectMarks == null)
          {
              return Problem("Entity set 'StudentDbContext.SubjectMarks'  is null.");
          }
            _context.SubjectMarks.Add(subjectMarks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectMarks", new { id = subjectMarks.Id }, subjectMarks);
        }

        // DELETE: api/SubjectMarks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectMarks(int id)
        {
            if (_context.SubjectMarks == null)
            {
                return NotFound();
            }
            var subjectMarks = await _context.SubjectMarks.FindAsync(id);
            if (subjectMarks == null)
            {
                return NotFound();
            }

            _context.SubjectMarks.Remove(subjectMarks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectMarksExists(int id)
        {
            return (_context.SubjectMarks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

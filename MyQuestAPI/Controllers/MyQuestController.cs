using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyQuestAPI.Models;

namespace MyQuestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyQuestController : ControllerBase
    {
        private readonly MyQuestContext _context;

        public MyQuestController(MyQuestContext context)
        {
            _context = context;
        }

        // GET: api/MyQuest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
          if (_context.Questions == null)
          {
              return NotFound();
          }
            return await _context.Questions.Include(q => q.Options).ToListAsync();
        }

        // GET: api/MyQuest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
          if (_context.Questions == null)
          {
              return NotFound();
          }
            var question = await _context.Questions.Include(q => q.Options).FirstOrDefaultAsync(q => q.Id == id);
            
            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // POST: api/MyQuest
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
          if (_context.Questions == null)
          {
              return Problem("Entity set 'MyQuestContext.Questions'  is null.");
          }
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        }

        private bool QuestionExists(int id)
        {
            return (_context.Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

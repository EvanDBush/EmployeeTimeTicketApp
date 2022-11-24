using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeTimeTicketApp.Data;
using EmployeeTimeTicketApp.Domain;

namespace EmployeeTimeTicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTicketsController : ControllerBase
    {
        private readonly EmployeeTimeTicketContext _context;
        
        public TimeTicketsController(EmployeeTimeTicketContext context)
        {
            _context = context;
        }

        // GET: api/TimeTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeTicket>>> GetTimeTickets()
        {
            return await _context.TimeTickets.ToListAsync();
        }

        // GET: api/TimeTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeTicket>> GetTimeTicket(int id)
        {
            var timeTicket = await _context.TimeTickets.FindAsync(id);

            if (timeTicket == null)
            {
                return NotFound();
            }

            return timeTicket;
        }

        // PUT: api/TimeTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeTicket(int id, TimeTicket timeTicket)
        {
            if (id != timeTicket.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeTicketExists(id))
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

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TimeTicket>> PostTimeTicket(TimeTicket timeTicket)
        {
            _context.TimeTickets.Add(timeTicket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeTicket", new { id = timeTicket.Id }, timeTicket);
        }

        // DELETE: api/TimeTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeTicket(int id)
        {
            var timeTicket = await _context.TimeTickets.FindAsync(id);
            if (timeTicket == null)
            {
                return NotFound();
            }

            _context.TimeTickets.Remove(timeTicket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeTicketExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Inventaire.Data;
using API_Inventaire.Models;

namespace API_Inventaire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly API_InventaireContext _context;

        public UsersController(API_InventaireContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var _users = await _context.Users.ToListAsync();
            return Ok(_users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            var _users = await _context.Users.FindAsync(id);

            if (_users == null)
            {
                return NotFound();
            }

            return Ok(_users);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, users _users)
        {
            if (id != _users.id)
            {
                return BadRequest();
            }

            _context.Entry(_users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<users>> PostUsers(users _users)
        {
            _context.Users.Add(_users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = _users.id }, _users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.id == id);
        }
    }
}

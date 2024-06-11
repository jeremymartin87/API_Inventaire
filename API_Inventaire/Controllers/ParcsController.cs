using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Inventaire.Data;
using API_Inventaire.Models;

namespace API_Inventaire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcsController : ControllerBase
    {
        private readonly API_InventaireContext _context;

        public ParcsController(API_InventaireContext context)
        {
            _context = context;
        }

        // GET: api/Parcs
        [HttpGet]
        public async Task<IActionResult> GetParcs()
        {
            var parcs = await _context.parcs.ToListAsync();
            return Ok(parcs);
        }

        // GET: api/Parcs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParc(int id)
        {
            var parc = await _context.parcs.FindAsync(id);

            if (parc == null)
            {
                return NotFound();
            }

            return Ok(parc);
        }

        // PUT: api/Parcs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParc(int id, parcs parc)
        {

            var parc2 = await _context.parcs.FindAsync(id);

            parc2.name = parc.name;
            parc2.userid = parc.userid;
            parc2.isenabled = parc.isenabled;
            parc2.updatedat = DateTime.UtcNow;

            if (id != parc.id)
            {
                return BadRequest();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcExists(id))
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

        // POST: api/Parcs
        [HttpPost]
        public async Task<ActionResult<parcs>> PostParc(parcs parc)
        {
            _context.parcs.Add(parc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParc", new { id = parc.id }, parc);
        }

        // DELETE: api/Parcs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParc(int id)
        {
            var parc = await _context.parcs.FindAsync(id);
            if (parc == null)
            {
                return NotFound();
            }

            _context.parcs.Remove(parc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParcExists(int id)
        {
            return _context.parcs.Any(e => e.id == id);
        }
    }
}

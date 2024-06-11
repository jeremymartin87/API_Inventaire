using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Inventaire.Data;
using API_Inventaire.Models;

namespace API_Inventaire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly API_InventaireContext _context;

        public RoomsController(API_InventaireContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return Ok(rooms);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, rooms room)
        {

            var room2 = await _context.Rooms.FindAsync(id);

            room2.name = room.name;
            room2.parcid = room.parcid;
            room2.updatedat = DateTime.UtcNow;

            if (id != room.id)
            {
                return BadRequest();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<rooms>> PostRoom(rooms room)
        {
            room.createdat = DateTime.UtcNow;
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.id == id);
        }

        // GET: api/Rooms/byParc/5
        [HttpGet("byParc/{parcId}")]
        public async Task<IActionResult> GetRoomsByParc(int parcId)
        {
            var rooms = await _context.Rooms.Where(r => r.parcid == parcId).ToListAsync();

            if (rooms == null || !rooms.Any())
            {
                return NotFound();
            }

            return Ok(rooms);
        }
    }
}

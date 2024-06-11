using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Inventaire.Data;
using API_Inventaire.Models;

namespace API_Inventaire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly API_InventaireContext _context;

        public DevicesController(API_InventaireContext context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await _context.devices.ToListAsync();
            return Ok(devices);
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevice(int id)
        {
            var device = await _context.devices.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return Ok(device);
        }

        // PUT: api/Devices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, devices device)
        {
            if (id != device.id)
            {
                return BadRequest();
            }

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
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

        // POST: api/Devices
        [HttpPost]
        public async Task<ActionResult<devices>> PostDevice(devices device)
        {
            _context.devices.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevice", new { id = device.id }, device);
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _context.devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeviceExists(int id)
        {
            return _context.devices.Any(e => e.id == id);
        }

        // GET: api/Devices/byRoom/5
        [HttpGet("byRoom/{roomId}")]
        public async Task<IActionResult> GetDevicesByParc(int roomId)
        {
            var devices = await _context.devices.Where(r => r.roomid == roomId).ToListAsync();

            if (devices == null || !devices.Any())
            {
                return NotFound();
            }

            return Ok(devices);
        }
    }
}

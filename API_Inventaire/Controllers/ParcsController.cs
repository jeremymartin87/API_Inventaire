﻿using Microsoft.AspNetCore.Mvc;
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
            var parcs = await _context.Parcs.ToListAsync();
            return Ok(parcs);
        }

        // GET: api/Parcs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParc(int id)
        {
            var parc = await _context.Parcs.FindAsync(id);

            if (parc == null)
            {
                return NotFound();
            }

            return Ok(parc);
        }

        // PUT: api/Parcs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParc(int id, Parcs parc)
        {
            if (id != parc.Id)
            {
                return BadRequest();
            }

            _context.Entry(parc).State = EntityState.Modified;

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
        public async Task<ActionResult<Parcs>> PostParc(Parcs parc)
        {
            _context.Parcs.Add(parc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParc", new { id = parc.Id }, parc);
        }

        // DELETE: api/Parcs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParc(int id)
        {
            var parc = await _context.Parcs.FindAsync(id);
            if (parc == null)
            {
                return NotFound();
            }

            _context.Parcs.Remove(parc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParcExists(int id)
        {
            return _context.Parcs.Any(e => e.Id == id);
        }
    }
}
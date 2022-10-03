using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sabores_Backend.Models;

namespace Sabores_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentumsController : ControllerBase
    {
        private readonly SABORESContext _context;

        public VentumsController(SABORESContext context)
        {
            _context = context;
        }

        // GET: api/Ventums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventum>>> GetVenta()
        {
          if (_context.Venta == null)
          {
              return NotFound();
          }
            return await _context.Venta.ToListAsync();
        }

        // GET: api/Ventums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ventum>> GetVentum(int id)
        {
          if (_context.Venta == null)
          {
              return NotFound();
          }
            var ventum = await _context.Venta.FindAsync(id);

            if (ventum == null)
            {
                return NotFound();
            }

            return ventum;
        }

        // PUT: api/Ventums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentum(int id, Ventum ventum)
        {
            if (id != ventum.IdVenta)
            {
                return BadRequest();
            }

            _context.Entry(ventum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentumExists(id))
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

        // POST: api/Ventums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ventum>> PostVentum(Ventum ventum)
        {
          if (_context.Venta == null)
          {
              return Problem("Entity set 'SABORESContext.Venta'  is null.");
          }
            _context.Venta.Add(ventum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentum", new { id = ventum.IdVenta }, ventum);
        }

        // DELETE: api/Ventums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentum(int id)
        {
            if (_context.Venta == null)
            {
                return NotFound();
            }
            var ventum = await _context.Venta.FindAsync(id);
            if (ventum == null)
            {
                return NotFound();
            }

            _context.Venta.Remove(ventum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentumExists(int id)
        {
            return (_context.Venta?.Any(e => e.IdVenta == id)).GetValueOrDefault();
        }
    }
}

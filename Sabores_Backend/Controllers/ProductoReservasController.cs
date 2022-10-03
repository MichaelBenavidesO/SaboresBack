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
    public class ProductoReservasController : ControllerBase
    {
        private readonly SABORESContext _context;

        public ProductoReservasController(SABORESContext context)
        {
            _context = context;
        }

        // GET: api/ProductoReservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoReserva>>> GetProductoReservas()
        {
          if (_context.ProductoReservas == null)
          {
              return NotFound();
          }
            return await _context.ProductoReservas.ToListAsync();
        }

        // GET: api/ProductoReservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoReserva>> GetProductoReserva(int id)
        {
          if (_context.ProductoReservas == null)
          {
              return NotFound();
          }
            var productoReserva = await _context.ProductoReservas.FindAsync(id);

            if (productoReserva == null)
            {
                return NotFound();
            }

            return productoReserva;
        }

        // PUT: api/ProductoReservas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoReserva(int id, ProductoReserva productoReserva)
        {
            if (id != productoReserva.IdProductoReserva)
            {
                return BadRequest();
            }

            _context.Entry(productoReserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoReservaExists(id))
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

        // POST: api/ProductoReservas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductoReserva>> PostProductoReserva(ProductoReserva productoReserva)
        {
          if (_context.ProductoReservas == null)
          {
              return Problem("Entity set 'SABORESContext.ProductoReservas'  is null.");
          }
            _context.ProductoReservas.Add(productoReserva);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductoReservaExists(productoReserva.IdProductoReserva))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductoReserva", new { id = productoReserva.IdProductoReserva }, productoReserva);
        }

        // DELETE: api/ProductoReservas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoReserva(int id)
        {
            if (_context.ProductoReservas == null)
            {
                return NotFound();
            }
            var productoReserva = await _context.ProductoReservas.FindAsync(id);
            if (productoReserva == null)
            {
                return NotFound();
            }

            _context.ProductoReservas.Remove(productoReserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoReservaExists(int id)
        {
            return (_context.ProductoReservas?.Any(e => e.IdProductoReserva == id)).GetValueOrDefault();
        }
    }
}

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
    public class ProductoVentumsController : ControllerBase
    {
        private readonly SABORESContext _context;

        public ProductoVentumsController(SABORESContext context)
        {
            _context = context;
        }

        // GET: api/ProductoVentums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoVentum>>> GetProductoVenta()
        {
          if (_context.ProductoVenta == null)
          {
              return NotFound();
          }
            return await _context.ProductoVenta.ToListAsync();
        }

        // GET: api/ProductoVentums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoVentum>> GetProductoVentum(int id)
        {
          if (_context.ProductoVenta == null)
          {
              return NotFound();
          }
            var productoVentum = await _context.ProductoVenta.FindAsync(id);

            if (productoVentum == null)
            {
                return NotFound();
            }

            return productoVentum;
        }

        // PUT: api/ProductoVentums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductoVentum(int id, ProductoVentum productoVentum)
        {
            if (id != productoVentum.IdProductoVenta)
            {
                return BadRequest();
            }

            _context.Entry(productoVentum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoVentumExists(id))
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

        // POST: api/ProductoVentums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductoVentum>> PostProductoVentum(ProductoVentum productoVentum)
        {
          if (_context.ProductoVenta == null)
          {
              return Problem("Entity set 'SABORESContext.ProductoVenta'  is null.");
          }
            _context.ProductoVenta.Add(productoVentum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductoVentumExists(productoVentum.IdProductoVenta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductoVentum", new { id = productoVentum.IdProductoVenta }, productoVentum);
        }

        // DELETE: api/ProductoVentums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductoVentum(int id)
        {
            if (_context.ProductoVenta == null)
            {
                return NotFound();
            }
            var productoVentum = await _context.ProductoVenta.FindAsync(id);
            if (productoVentum == null)
            {
                return NotFound();
            }

            _context.ProductoVenta.Remove(productoVentum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoVentumExists(int id)
        {
            return (_context.ProductoVenta?.Any(e => e.IdProductoVenta == id)).GetValueOrDefault();
        }
    }
}

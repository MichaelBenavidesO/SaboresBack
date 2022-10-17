using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sabores_Backend.Models;
using Sabores_Backend.ModelsView;

namespace Sabores_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoesController : ControllerBase
    {
        private readonly SABORESContext _context;

        public ProductoesController(SABORESContext context)
        {
            _context = context;
        }

        // GET: api/Productoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
          if (_context.Productos == null)
          {
              return NotFound();
          }
            return await _context.Productos.ToListAsync();
        }

        // GET: api/Productoes/false
       [HttpGet]
        [Route("estado/{estado}")]

        public async Task<ActionResult<IEnumerable<ProductoActivoMV>>> GetProductoActivo(bool estado)
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }


            var query = (from pro in _context.Productos
                         where pro.Estado == estado
                         select new ProductoActivoMV
                         {
                             Descripcion = pro.Descripcion,
                             Imagen = pro.Imagen,
                             NombreProducto = pro.NombreProducto,
                             Precio = pro.Precio,

                         }).ToListAsync();

            return await query;


        }

        // GET: api/Productoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
          if (_context.Productos == null)
          {
              return NotFound();
          }
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        

        // PUT: api/Productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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

        // POST: api/Productoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
          if (_context.Productos == null)
          {
              return Problem("Entity set 'SABORESContext.Productos'  is null.");
          }
            _context.Productos.Add(producto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductoExists(producto.IdProducto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProducto", new { id = producto.IdProducto }, producto);
        }

        // DELETE: api/Productoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            if (_context.Productos == null)
            {
                return NotFound();
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(int id)
        {
            return (_context.Productos?.Any(e => e.IdProducto == id)).GetValueOrDefault();
        }
    }
}

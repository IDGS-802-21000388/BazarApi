using BazarUniversal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarUniversal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly BazarUniversalContext _context;

        public ProductosController(BazarUniversalContext context)
        {
            _context = context;
        }

        // GET: api/productos/items?q=query
        [HttpGet("items")]
        public IActionResult GetItems([FromQuery] string q)
        {
            var productos = _context.Productos
                .Where(p => p.Titulo.Contains(q))
                .Select(p => new {
                    p.Idproducto,
                    p.Titulo,
                    p.Descripcion,
                    p.Precio,
                    p.Categoria,
                    p.Fondo,
                    p.Clasificacion
                })
                .ToList();

            return Ok(productos);
        }

        // GET: api/productos/items/{id}
        [HttpGet("items/{id}")]
        public IActionResult GetItemById(int id)
        {
            var producto = _context.Productos
                .Where(p => p.Idproducto == id)
                .Select(p => new {
                    p.Idproducto,
                    p.Titulo,
                    p.Descripcion,
                    p.Precio,
                    p.Descuento,
                    p.Clasificacion,
                    p.Existencias,
                    p.Marca,
                    p.Categoria,
                    p.Fondo,
                    Imagenes = p.ImagenesProductos.Select(i => i.ImagenUrl)
                })
                .FirstOrDefault();

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }
    }

}

using BazarUniversal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazarUniversal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly BazarUniversalContext _context;

        public VentasController(BazarUniversalContext context)
        {
            _context = context;
        }

        // POST: api/ventas/addSale
        [HttpPost("addSale")]
        public IActionResult AddSale([FromBody] Venta venta)
        {
            if (!_context.Productos.Any(p => p.Idproducto == venta.Idproducto))
                return BadRequest("Producto no encontrado.");

            venta.FechaVenta = DateTime.Now;
            _context.Ventas.Add(venta);
            _context.SaveChanges();

            return Ok(true);
        }

        // GET: api/ventas/sales
        [HttpGet("sales")]
        public IActionResult GetSales()
        {
            var ventas = _context.Ventas
                .Select(v => new {
                    v.Idventa,
                    v.Idproducto,
                    v.Cantidad,
                    v.FechaVenta,
                    v.TotalVenta,
                    Producto = v.IdproductoNavigation.Titulo
                })
                .ToList();

            return Ok(ventas);
        }
    }
}

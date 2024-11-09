using System;
using System.Collections.Generic;

namespace BazarUniversal.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Descuento { get; set; }

    public decimal? Clasificacion { get; set; }

    public int? Existencias { get; set; }

    public string? Marca { get; set; }

    public string? Categoria { get; set; }

    public string? Fondo { get; set; }

    public virtual ICollection<ImagenesProducto> ImagenesProductos { get; set; } = new List<ImagenesProducto>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}

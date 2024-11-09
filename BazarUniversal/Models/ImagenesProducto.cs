using System;
using System.Collections.Generic;

namespace BazarUniversal.Models;

public partial class ImagenesProducto
{
    public int Idimagen { get; set; }

    public int? Idproducto { get; set; }

    public string? ImagenUrl { get; set; }

    public virtual Producto? IdproductoNavigation { get; set; }
}

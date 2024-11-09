using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BazarUniversal.Models;

public partial class Venta
{
    public int Idventa { get; set; }

    public int Idproducto { get; set; }

    public int Cantidad { get; set; }

    public DateTime FechaVenta { get; set; }

    public int TotalVenta { get; set; }

    [JsonIgnore]
    public virtual Producto? IdproductoNavigation { get; set; }
}

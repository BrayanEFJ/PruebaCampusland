using System;
using System.Collections.Generic;

namespace PruebaBrayanFigueroa.Models;

public partial class PedidoProducto
{
    public int? PedidoId { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public virtual Pedido? Pedido { get; set; }

    public virtual Producto? Producto { get; set; }
}

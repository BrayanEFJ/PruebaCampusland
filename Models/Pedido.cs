using System;
using System.Collections.Generic;

namespace PruebaBrayanFigueroa.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public DateTime? FechaPedido { get; set; }

    public decimal? Total { get; set; }

    public virtual Cliente? Client { get; set; }
}

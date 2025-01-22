using PruebaBrayanFigueroa.Models;

namespace PruebaBrayanFigueroa.Dto
{
    public class PedidosDto
    {
        public int Id { get; set; }

        public DateTime? FechaPedido { get; set; }

        public decimal? Total { get; set; }

        public virtual Cliente? Client { get; set; }

        public virtual PedidoProducto? PedidoProducto { get; set; }


    }
}

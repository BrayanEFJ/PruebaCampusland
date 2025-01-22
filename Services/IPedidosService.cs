using PruebaBrayanFigueroa.Dto;
using PruebaBrayanFigueroa.Models;

namespace PruebaBrayanFigueroa.Services
{
    public interface IPedidosService
    {
        public Task<Pedido> CrearPedido(Pedido pedido);

        public IQueryable<PedidosDto> TraerPedido(int id);

    }
}

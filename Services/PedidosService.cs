using System.Drawing;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using PruebaBrayanFigueroa.Dto;
using PruebaBrayanFigueroa.Errors;
using PruebaBrayanFigueroa.Models;

namespace PruebaBrayanFigueroa.Services
{
    public class PedidosService : IPedidosService
    {
        private readonly PruebaBfContext _db;

        public PedidosService(PruebaBfContext _Db)
        {
            _db = _Db;
        }

        public Task<Pedido> CrearPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }

    


        public IQueryable<PedidosDto> TraerPedido(int id)
        {
            try
            {
                var response = _db.PedidoProductos.Join(_db.Pedidos, pedprod => pedprod.PedidoId, ped => ped.Id, (pedprod, ped) =>

                    new PedidosDto
                    {
                        Id = ped.Id,
                        FechaPedido = ped.FechaPedido,
                        Total = ped.Total,
                        Client = ped.Client,
                        PedidoProducto = pedprod
                    }
                ).Where(ped => ped.Id == id);

                return response;

            }
            catch (CustomErrors ex)
            {
                throw new CustomErrors(404, "El pedido no ha sido encontrado");

            }



        }



    }
}

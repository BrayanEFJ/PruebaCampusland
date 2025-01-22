using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PruebaBrayanFigueroa.Dto;
using PruebaBrayanFigueroa.Errors;
using PruebaBrayanFigueroa.Services;

namespace PruebaBrayanFigueroa.Controllers
{

    [ApiController]
    [Route("api/pedidos/")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _serv;

        public PedidosController(IPedidosService _Serv)
        {
            _serv = _Serv;
        }


        [HttpGet("{id}")]
        public  IQueryable<PedidosDto> Pedidos(int id)
        {
            
            var response =  _serv.TraerPedido(id);
            return response;


        }



    }
}

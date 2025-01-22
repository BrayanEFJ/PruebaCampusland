

using Microsoft.AspNetCore.Mvc;
using PruebaBrayanFigueroa.Errors;
using PruebaBrayanFigueroa.Models;
using PruebaBrayanFigueroa.Services;

namespace PruebaBrayanFigueroa.Controllers
{
    [ApiController]
    [Route("api/clientes/")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _serv;

        public ClientesController(IClientesService _Serv)
        {
            _serv = _Serv;
        }


        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] Cliente client)
        {
            try
            {
                var response = await _serv.CreateClient(client);
                return Ok(new
                {
                    Message = "Cliente creado con exito",
                    Client = response,
                });
            }
            catch (CustomErrors ex)
            {
               return (ex.TocontentError());
            }
           
        }








    }
}

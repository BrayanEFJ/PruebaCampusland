using Microsoft.AspNetCore.Mvc;
using PruebaBrayanFigueroa.Errors;
using PruebaBrayanFigueroa.Models;
using PruebaBrayanFigueroa.Services;

namespace PruebaBrayanFigueroa.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {

        private readonly IProductosService _serv;

        public ProductosController(IProductosService _Serv)
        {
            _serv = _Serv;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(Decimal? precioinicial, Decimal? preciofinal, int? minimum_stock)
        {
            try
            {
                var response = await _serv.getProducts(precioinicial, preciofinal, minimum_stock);
                if (response.Count > 0)
                {
                    return Ok(new
                    {
                        Products = response,
                    });
                }
                else
                {
                    return Ok(new
                    {
                        message = "Al parecer no tenemos productos para lo que has filtrado.",
                        Products = response,
                    });
                }

            }
            catch (CustomErrors ex)
            {
                return (ex.TocontentError());
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducts(int id,[FromBody] Producto prd)
        {
            try
            {
                var response = _serv.updateProducts(id, prd);
                return Ok(new
                {
                    message="Tu producto ha sido actualizado con exito",
                    Products = response,
                });

            }
            catch (CustomErrors ex)
            {
                return (ex.TocontentError());
            }

            catch (AggregateException ex)
            {
                return NotFound(ex);
            }

        }

    }
}

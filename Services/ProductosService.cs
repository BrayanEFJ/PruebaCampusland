using Microsoft.EntityFrameworkCore;
using PruebaBrayanFigueroa.Errors;
using PruebaBrayanFigueroa.Models;

namespace PruebaBrayanFigueroa.Services
{
    public class ProductosService : IProductosService

    {

        private readonly PruebaBfContext _db;

        public ProductosService(PruebaBfContext _Db)
        {
            _db = _Db;
        }



        public async Task<List<Producto>> getProducts(Decimal? precioinicial, Decimal? preciofinal, int? minimum_stock)
        {
            if (precioinicial == null)
            {
                precioinicial = new Decimal(0);
            }
            if (preciofinal == null)
            {
                preciofinal = new Decimal(1000000000000);
            }
            if (minimum_stock == null)
            {
                minimum_stock = 0;
            }
            var response = await _db.Productos.Where(prod => prod.Precio>=precioinicial && prod.Precio <=preciofinal && prod.Stock >= minimum_stock).ToListAsync();
            return response;
        }

        public async Task<Producto> updateProducts(int id,Producto producto)
        {
            try
            {
                var response = _db.Productos.FirstOrDefault(prod => prod.Id == id);
                if (response == null)
                {
                    throw new CustomErrors(404, "Tu Producto no ha sido encontrado");
                }
                else
                {
                    response.Stock = producto.Stock;
                    response.Precio = producto.Precio;
                    await _db.SaveChangesAsync();
                    return response;
                }
            }
            catch (AggregateException ex) {

                throw new CustomErrors(404, "Tu Producto no ha sido encontrado");
            }
           

        }
    }
}

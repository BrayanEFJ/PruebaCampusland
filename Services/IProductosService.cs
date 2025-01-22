using PruebaBrayanFigueroa.Models;

namespace PruebaBrayanFigueroa.Services
{
    public interface IProductosService
    {
        public Task<List<Producto>> getProducts(Decimal? precioinicial, Decimal? preciofinal, int? minimum_stock);

        public Task<Producto> updateProducts(int id,Producto producto);
    }
}

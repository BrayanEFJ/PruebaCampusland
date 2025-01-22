using PruebaBrayanFigueroa.Models;

namespace PruebaBrayanFigueroa.Services
{
    public interface IClientesService
    {
        public Task<Cliente> CreateClient(Cliente cliente);

    }
}

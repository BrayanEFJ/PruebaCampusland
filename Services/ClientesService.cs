using PruebaBrayanFigueroa.Errors;
using PruebaBrayanFigueroa.Models;

namespace PruebaBrayanFigueroa.Services
{
    public class ClientesService : IClientesService
    {

        private readonly PruebaBfContext _db;

        public ClientesService(PruebaBfContext _Db)
        {
            _db = _Db;
        }

        public async Task<Cliente> CreateClient(Cliente cliente)
        {
            var existingemail = _db.Clientes.FirstOrDefault(user => user.Email == cliente.Email);

            if (existingemail != null)
            {
                throw new CustomErrors(409, "Tu correo ya existe en la base de datos, intenta con otro");
            }
            else
            {
                _db.Clientes.Add(cliente);
                await _db.SaveChangesAsync();
                return cliente;
            }

        }
    }
}

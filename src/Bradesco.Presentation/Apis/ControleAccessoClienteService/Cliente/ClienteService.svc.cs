using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleAccessoClienteService.Cliente
{
    public class ClienteService : IClienteService
    {
        ClienteService _clienteService;

        public ClienteService(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public Cliente Get(Guid idCliente)
        {
            var cliente = _clienteService.Get(idCliente);
            return new Cliente(cliente.Id, cliente.Cpf, cliente.Nome);
        }

        public IEnumerable<Cliente> Get()
        {
            var clientes = _clienteService.Get();
            return clientes.Select(x => new Cliente(x.Id, x.Cpf, x.Nome));
        }
    }
}

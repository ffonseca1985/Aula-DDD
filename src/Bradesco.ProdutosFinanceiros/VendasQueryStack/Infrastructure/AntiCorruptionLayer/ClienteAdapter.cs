using System.Collections.Generic;

namespace VendasQueryStack.Infrastructure.AntiCorruptionLayer
{
    using Application.Cliente;
    using System;
    using System.Linq;
    using VendasQueryStack.ClienteServiceReference;

    public class ClienteAdapter
    {
        ClienteServiceClient _clienteService;

        public ClienteAdapter()
        {
            _clienteService = new ClienteServiceClient();
        }

        public ClienteDto Get(Guid id)
        {
            var cliente = _clienteService.Get(id);
            return new ClienteDto(cliente.Cpf, cliente.Nome);
        }

        public List<ClienteDto> GetAll()
        {
            var clientes = _clienteService.GetAll();
            return clientes.Select(x => new ClienteDto(x.Cpf, x.Nome)).ToList();
        }
    }
}

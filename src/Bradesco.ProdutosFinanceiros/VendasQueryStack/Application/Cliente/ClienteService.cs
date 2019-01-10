using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendasQueryStack.Infrastructure.AntiCorruptionLayer;

namespace VendasQueryStack.Application.Cliente
{
    //quando usamos cqrs não precisa de DomainModel
    //Chamamos direto da Infra
    public class ClienteService
    {
        ClienteAdapter _adapter;

        public ClienteService(ClienteAdapter adapter)
        {
            _adapter = adapter;
        }

        public ClienteDto Get(Guid id)
        {
            return _adapter.Get(id);
        }

        public List<ClienteDto> GetAll()
        {
            return _adapter.GetAll();
        }
    }
}

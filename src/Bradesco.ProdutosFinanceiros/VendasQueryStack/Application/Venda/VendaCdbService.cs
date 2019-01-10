using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendasQueryStack.Infrastructure.Repositories;
using VendasQueryStack.Infrastructure.Repositories.Dtos;

namespace VendasQueryStack.Application.Venda
{
    public class VendaCdbService
    {
        VendaRepository _vendaRepository;

        public VendaCdbService(VendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<IEnumerable<VendaCDBDto>> Get()
        {
            return await _vendaRepository.GetVendaCdb();
        }
    }
}

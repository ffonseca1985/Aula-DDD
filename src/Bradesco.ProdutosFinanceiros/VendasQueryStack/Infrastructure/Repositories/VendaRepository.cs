using SharedKernel.InfraEstructure.NoRelationalData;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendasQueryStack.Infrastructure.Repositories.Dtos;

namespace VendasQueryStack.Infrastructure.Repositories
{
    public class VendaRepository
    {
        public async Task<IEnumerable<VendaCDBDto>> GetVendaCdb()
        {
            var store = new NoRelationalStore<VendaCDBDto>();
            return await store.GetAll(dataBase: "Venda", collectionName: "VendaCdb");
        }
    }
}

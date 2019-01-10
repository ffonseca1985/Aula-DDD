using CQRSlite.Bus;
using CQRSlite.Commands;

namespace Vendas.Application.Venda
{
    using DomainModel.Venda;
    using Vendas.Commands;
    using Vendas.Infraestructure.SqlEntityFramework.Repositories;

    public class VendaService
    {
        InProcessBus _bus;
        RepositoryBase<Venda> _vendaRepository;

        public VendaService(InProcessBus bus,
            RepositoryBase<Venda> vendaRepository)
        {
            _bus = bus;
            _vendaRepository = vendaRepository;
        }

       public void Executar(VenderCDBCommand command)
       {
            //Como fizemos só este contexto com cqrslite
            //não vamos validar para evitar a fadiga
            _bus.Send(command);
       }
    }
}

using CQRSlite.Bus;
using CQRSlite.Cache;
using CQRSlite.Domain;
using CQRSlite.Events;
using SimpleInjector;
using Vendas.Application.Venda;
using Vendas.DomainModel.Venda;
using Vendas.EventStore;
using Vendas.Infraestructure.SqlEntityFramework.Contexts;
using Vendas.Infraestructure.SqlEntityFramework.Repositories;

namespace Vendas.Infraestructure.ServiceLocator
{
    public static class Bootstrap
    {
        public static void InitializeVendasCommand(this Container container, Lifestyle lifestyle)
        {
            container.Register<VendaContext>(lifestyle);
            container.Register<VendaService>(lifestyle);
            container.Register<RepositoryBase<Venda>>(lifestyle);

            container.Register<InProcessBus>(lifestyle);
            container.Register<IHandlerRegistrar, InProcessBus>(lifestyle);

            container.Register<ICache, MemoryCache>(lifestyle);
            container.Register<IEventStore, InMemoryEventStore>(lifestyle);

            container.Register<IRepository>
                (() => new CacheRepository(new Repository(container.GetInstance<IEventStore>()),
                                              container.GetInstance<IEventStore>(),
                                              container.GetInstance<ICache>()
                                          ), lifestyle
                );
        }
    }
}

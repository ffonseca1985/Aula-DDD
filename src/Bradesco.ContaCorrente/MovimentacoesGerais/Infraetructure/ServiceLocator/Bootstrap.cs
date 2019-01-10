using MovimentacoesGerais.Application.CommandHandlers;
using MovimentacoesGerais.Application.ContaCorrente;
using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Context;
using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories;
using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories.PersistModels;
using SimpleInjector;

namespace MovimentacoesGerais.Infraetructure.ServiceLocator
{
    public static class Bootstrap
    {
        public static void InitializeMovimentacoesGerais(this Container container, Lifestyle lifestyle)
        {
            container.Register<MovimentacoesGeraisContext>(lifestyle);
            container.Register<ContaCorrenteService>(lifestyle);
            container.Register<RepositorioDeContaCorrente>(lifestyle);
            container.Register<EventStore<PosicaoAtualContaCorrente>>(lifestyle);

            container.Register<ComprarCdbCommandHandler>(lifestyle);
            container.Register<CriarCommandHandler>(lifestyle);
            container.Register<DepositarCommandhandler>(lifestyle);
            container.Register<EmprestimoCommandHandler>(lifestyle);
            container.Register<EncerrarCommandHandler>(lifestyle);
            container.Register<SacarCommandHandler>(lifestyle);
        }
    }
}

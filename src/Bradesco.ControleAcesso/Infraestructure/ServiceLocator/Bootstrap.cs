
using ControleAcesso.Application.Cliente;
using ControleAcesso.DomainModel.Cliente;
using ControleAcesso.Infraestructure.SqlEntityFramework.Contexts;
using ControleAcesso.Infraestructure.SqlEntityFramework.Repository;
using SimpleInjector;

namespace ControleAcesso.Infraestructure.ServiceLocator
{
    public static class Bootstrap
    {
        public static void InitializeControleAcesso(this Container container, Lifestyle lifestyle)
        {
            container.Register<ControleAcessoContext>(lifestyle);
            container.Register<RepositoryBase<Cliente>>(lifestyle);
            container.Register<ClienteService>(lifestyle);
        }
    }
}

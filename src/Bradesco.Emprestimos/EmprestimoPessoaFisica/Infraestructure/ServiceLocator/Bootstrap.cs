using EmprestimoPessoaFisica.Application.EventHandlers;
using EmprestimoPessoaFisica.DomainModel.EmprestimoGeral;
using EmprestimoPessoaFisica.Infraestructure.SqlEntityFramework.Contexts;
using EmprestimoPessoaFisica.Infraestructure.SqlEntityFramework.Repository;
using SimpleInjector;

namespace EmprestimoPessoaFisica.Infraestructure.ServiceLocator
{

    using AP = Application.EmprestimoGeral;

    public static class Bootstrap
    {
        public static void RegisterPessoaFisica(this Container container, Lifestyle lifestyle)
        {
            container.Register<EmprestoPessoFisicaContext>(lifestyle);
            container.Register<AP.EmprestimoGeralService>(lifestyle);
            container.Register<RepositoryBase<EmprestimoGeral>>(lifestyle);
            container.Register<EmprestimoEventHandler>(lifestyle);
        }
    }
}

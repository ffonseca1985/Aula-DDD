using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;

using ControleAcesso.Infraestructure.ServiceLocator;
using SharedKernel.InfraEstructure.ServiceLocator;
using CommonServiceLocator.SimpleInjectorAdapter;
using MovimentacoesGerais.Infraetructure.ServiceLocator;
using Microsoft.Practices.ServiceLocation;
using SharedKernel.InfraEstructure.Messages;
using BusMessage.ServiceLocator;
using BusMessage.Configure;
using EmprestimoPessoaFisica.Infraestructure.ServiceLocator;
using Vendas.Infraestructure.ServiceLocator;
using CQRSlite.Config;
using Vendas.CommandHandlers;

namespace SistemaBancarioSiteWeb.App_Start
{
    public static class ServiceLocatorConfig
    {
        public static void Initialize()
        {
            var container = new Container();

            container.Options.DefaultLifestyle = new WebRequestLifestyle();

            container.RegisterMvcControllers();

            //Initialize
            container.InitializeControleAcesso(new WebRequestLifestyle());
            container.InitializeSharedKernel(new WebRequestLifestyle());
            container.InitializeMovimentacoesGerais(new WebRequestLifestyle());
            container.RegisterPessoaFisica(new WebRequestLifestyle());
            container.InitializeBus(new WebRequestLifestyle());
            container.InitializeVendasCommand(new WebRequestLifestyle());

            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));

            //O Framework CQRSLite não registra evento!!
            //Só registra Command, ele pega os eventos do eventSource contida no aggregate
            //fala a verdade: CQRSLite é muito profissa!!!
            ConfigureBus(container, new WebRequestLifestyle());

            container.Verify();

            //Tem o objetivo de resolver pendencias que o "chamador" não consegue 
            //resolver
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        public static void ConfigureBus(Container container, Lifestyle lifestyle)
        {
            var bus = container.GetInstance<IBus>();
            bus.Initialize();
        }
    }
}
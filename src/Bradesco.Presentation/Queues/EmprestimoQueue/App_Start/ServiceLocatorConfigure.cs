using SimpleInjector;
using MovimentacoesGerais.Infraetructure.ServiceLocator;
using SharedKernel.InfraEstructure.ServiceLocator;
using SharedKernel.InfraEstructure.Messages;
using BusMessage.Configure;
using Microsoft.Practices.ServiceLocation;
using CommonServiceLocator.SimpleInjectorAdapter;

using BusMessage.ServiceLocator;

namespace EmprestimoQueue.App_Start
{
    public static class ServiceLocatorConfigure
    {
        public static void Configuration()
        {
            var container = new Container();

            container.Options.DefaultLifestyle = Lifestyle.Singleton;

            container.InitializeMovimentacoesGerais(Lifestyle.Singleton);
            container.InitializeSharedKernel(Lifestyle.Singleton);
            container.InitializeBus(Lifestyle.Singleton);

            ConfigureBus(container);

            container.Verify();

            ServiceLocator.SetLocatorProvider(() => new SimpleInjectorServiceLocatorAdapter(container));
        }

        public static void ConfigureBus(Container container)
        {
            var bus = container.GetInstance<IBus>();
            bus.Initialize();
        }
    }
}

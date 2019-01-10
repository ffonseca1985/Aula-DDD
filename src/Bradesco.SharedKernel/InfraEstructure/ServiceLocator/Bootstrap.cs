using SharedKernel.DomainModel.Events;
using SharedKernel.EventHandlers;
using SharedKernel.InfraEstructure.Messages;
using SimpleInjector;

namespace SharedKernel.InfraEstructure.ServiceLocator
{
    public static class Bootstrap
    {
        public static void InitializeSharedKernel(this Container container, Lifestyle lifestyle)
        {
            container.Register<ExceptionEventHandler>(lifestyle);
        }
    }
}

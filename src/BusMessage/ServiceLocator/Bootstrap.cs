using BusMessage.Configure;
using SharedKernel.InfraEstructure.Messages;
using SimpleInjector;

namespace BusMessage.ServiceLocator
{
    public static class Bootstrap
    {
        public static void InitializeBus(this Container container, Lifestyle lifestyle)
        {
            container.Register<IBus, Bus>(lifestyle);
        }
    }
}

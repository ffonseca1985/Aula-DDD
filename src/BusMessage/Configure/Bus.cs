using SharedKernel.InfraEstructure.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusMessage.Configure
{
    public class Bus : IBus
    {
        private static Dictionary<Type, Type> _handlers = new Dictionary<Type, Type>();

        public void Register<T>() where T : HandlerBase
        {
            Type type = typeof(T);

            var messageType = type.
                GetInterfaces().First(i => i.Name.StartsWith(typeof(IHandlerMessage<>).Name));

            _handlers.Add(type, messageType);
        }

        public void Publish<T>(T @event) where T : IEvent
        {
            var type = @event.GetType();

            var interfaceCommand = typeof(IHandlerMessage<>).MakeGenericType(type);

            var list = _handlers.Keys.Where(x => interfaceCommand.IsAssignableFrom(x))
                    .Select(x => x);

            foreach (Type item in list)
            {
                dynamic intance = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance(item);
                intance.Handle(@event);
            }
        }

        public void Send<T>(T command) where T : ICommand
        {
            var type = command.GetType();

            var interfaceCommand = typeof(IHandlerMessage<>).MakeGenericType(type);

            var list = _handlers.Keys.Where(x => interfaceCommand.IsAssignableFrom(x))
                    .Select(x => x);

            foreach (Type item in list)
            {
                dynamic intance = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance(item);
                intance.Handle(command);
            }
        }
    }
}

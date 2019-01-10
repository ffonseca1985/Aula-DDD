namespace SharedKernel.InfraEstructure.Messages
{
    public interface IBus
    {
        void Publish<T>(T @event) where T : IEvent;
        void Send<T>(T command) where T : ICommand;
        void Register<T>() where T : HandlerBase;
    }
}

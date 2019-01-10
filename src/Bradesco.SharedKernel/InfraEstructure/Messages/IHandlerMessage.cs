using System.Threading.Tasks;

namespace SharedKernel.InfraEstructure.Messages
{
    public interface IHandlerMessage<T>
        where T : IMessage
    {
        void Handle(T message);
    }
}

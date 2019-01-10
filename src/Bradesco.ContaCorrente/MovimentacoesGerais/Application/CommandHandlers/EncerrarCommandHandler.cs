using MovimentacoesGerais.Application.ContaCorrente.Commands;
using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories;
using SharedKernel.DomainModel.Events;
using SharedKernel.InfraEstructure.Messages;
using System.Threading.Tasks;

namespace MovimentacoesGerais.Application.CommandHandlers
{
    public class EncerrarCommandHandler
        : HandlerBase, 
        IHandlerMessage<EncerrarCommand>
    {
        RepositorioDeContaCorrente _ccRepository;
        IBus _bus;

        public EncerrarCommandHandler(RepositorioDeContaCorrente ccRepository,
            IBus bus)
        {
            _ccRepository = ccRepository;
            _bus = bus;
        }

        public void Handle(EncerrarCommand message)
        {
                var contaCorrente = _ccRepository.BuscarPor(message.IdContaCorrente);

                if (contaCorrente == null)
                {
                    _bus.Publish(new ExceptionEvent("Conta Corrente", "Conta corrente inexistente"));
                    return;
                }

                contaCorrente.Encerrar(message.Motivo);
                _ccRepository.Salvar(contaCorrente);
        }
    }
}

using MovimentacoesGerais.Application.Commands;
using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories;
using SharedKernel.DomainModel.Events;
using SharedKernel.InfraEstructure.Messages;
using System.Threading.Tasks;

namespace MovimentacoesGerais.Application.CommandHandlers
{
    public class SacarCommandHandler
        : HandlerBase, 
        IHandlerMessage<SacarCommand>

    {
        RepositorioDeContaCorrente _ccRepository;
        IBus _bus;

        public SacarCommandHandler(RepositorioDeContaCorrente ccRepository,
            IBus bus)
        {
            _ccRepository = ccRepository;
            _bus = bus;
        }

        public void Handle(SacarCommand message)
        {
                var contaCorrente = _ccRepository.BuscarPor(message.IdContaCorrente);

                if (contaCorrente == null)
                {
                    _bus.Publish(new ExceptionEvent("Conta Corrente", "Conta corrente inexistente"));
                    return;
                }

                contaCorrente.Sacar(message.Valor);

                _ccRepository.Salvar(contaCorrente);
        }
    }
}

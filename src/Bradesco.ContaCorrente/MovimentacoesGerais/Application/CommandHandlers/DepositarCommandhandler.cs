using MovimentacoesGerais.Application.ContaCorrente.Commands;
using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories;
using SharedKernel.DomainModel.Events;
using SharedKernel.InfraEstructure.Messages;
using System.Threading.Tasks;

namespace MovimentacoesGerais.Application.CommandHandlers
{
    public class DepositarCommandhandler
        : HandlerBase, 
        IHandlerMessage<DepositarCommand>
    {
        RepositorioDeContaCorrente _ccRepository;
        IBus _bus;

        public DepositarCommandhandler(RepositorioDeContaCorrente ccRepository,
            IBus bus)
        {
            _ccRepository = ccRepository;
            _bus = bus;
        }

        public void Handle(DepositarCommand message)
        {
                var contaCorrente = _ccRepository.BuscarPor(message.IdContaCorrente);

                if (contaCorrente == null)
                {
                    _bus.Publish(new ExceptionEvent("Conta Corrente", "Conta corrente inexistente"));
                    return;
                }

                contaCorrente.Depositar(message.Valor);
                _ccRepository.Salvar(contaCorrente);
        }
    }
}

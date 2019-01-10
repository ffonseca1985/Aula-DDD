using MovimentacoesGerais.Application.Commands;
using SharedKernel.InfraEstructure.Messages;

namespace MovimentacoesGerais.Application.CommandHandlers
{
    using DomainModel.ContaCorrente;
    using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories;
    using SharedKernel.DomainModel.Events;
    using System.Threading.Tasks;

    public class CriarCommandHandler
        : HandlerBase, 
        IHandlerMessage<CriarCommand>
    {
        RepositorioDeContaCorrente _ccRepository;
        IBus _bus;

        public CriarCommandHandler(RepositorioDeContaCorrente ccRepository,
            IBus bus)
        {
            _ccRepository = ccRepository;
            _bus = bus;
        }

        public void Handle(CriarCommand message)
        {
            var contaCorrente = _ccRepository.BuscarPor(message.IdContaCorrente);

            if (contaCorrente != null)
            {
                _bus.Publish(new ExceptionEvent("Conta Corrente", "Conta corrente existente"));
                return;
            }

            var cc = new ContaCorrente(message.IdCliente, message.NumeroConta, message.NumeroAgencia);
            _ccRepository.Salvar(cc);
        }
    }
}

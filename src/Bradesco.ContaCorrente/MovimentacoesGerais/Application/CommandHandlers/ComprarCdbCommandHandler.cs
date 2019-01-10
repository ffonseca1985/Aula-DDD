using MovimentacoesGerais.Application.ContaCorrente.Commands;
using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories;
using SharedKernel.DomainModel.Events;
using SharedKernel.InfraEstructure.Messages;
using System.Threading.Tasks;

namespace MovimentacoesGerais.Application.CommandHandlers
{
    public class ComprarCdbCommandHandler
        : HandlerBase, 
        IHandlerMessage<ComprarCdbCommand>
    {
        RepositorioDeContaCorrente _ccRepository;
        IBus _bus;

        public ComprarCdbCommandHandler(RepositorioDeContaCorrente ccRepository,
            IBus bus)
        {
            _ccRepository = ccRepository;
            _bus = bus;
        }

        public void Handle(ComprarCdbCommand message)
        {
                var contaCorrente = _ccRepository.BuscarPor(message.IdContaCorrente);

                if (contaCorrente == null)
                {
                    _bus.Publish(new ExceptionEvent("Conta Corrente", "Conta corrente inexistente"));
                    return;
                }

                contaCorrente.ComprarCdb(message.IdProdutoFinanceiro, message.Valor);
                _ccRepository.Salvar(contaCorrente);
        }
    }
}

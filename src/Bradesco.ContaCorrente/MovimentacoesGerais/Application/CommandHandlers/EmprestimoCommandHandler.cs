using MovimentacoesGerais.Application.ContaCorrente.Commands;
using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories;
using SharedKernel.DomainModel.Events;
using SharedKernel.InfraEstructure.Messages;
using System.Threading.Tasks;

namespace MovimentacoesGerais.Application.CommandHandlers
{
    public class EmprestimoCommandHandler :
        HandlerBase,
        IHandlerMessage<EmprestimoCommand>
    {
        RepositorioDeContaCorrente _ccRepository;
        IBus _bus;

        public EmprestimoCommandHandler(RepositorioDeContaCorrente ccRepository,
            IBus bus)
        {
            _ccRepository = ccRepository;
            _bus = bus;
        }

        public void Handle(EmprestimoCommand message)
        {
            var contaCorrente = _ccRepository.BuscarPor(message.IdContaCorrente);

            if (contaCorrente == null)
            {
                _bus.Publish(new ExceptionEvent("Conta Corrente", "Conta corrente inexistente"));
                return;
            }
            contaCorrente.RealizarEmprestimo(message.IdEmprestimo, message.Valor);
            _ccRepository.Salvar(contaCorrente);
        }
    }
}

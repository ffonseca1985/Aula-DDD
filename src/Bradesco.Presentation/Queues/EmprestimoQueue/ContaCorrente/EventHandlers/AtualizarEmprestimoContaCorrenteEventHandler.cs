using MassTransit;
using MovimentacoesGerais.Application.ContaCorrente;
using MovimentacoesGerais.Application.ContaCorrente.Commands;
using SharedKernel.InfraEstructure.Queue.Messages;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;


namespace EmprestimoQueue.ContaCorrente.EventHandlers
{
    public class AtualizarEmprestimoContaCorrenteEventHandler
        : IConsumer<IEmprestimo>
    {
        ContaCorrenteService _contaCorrenteService;

        public AtualizarEmprestimoContaCorrenteEventHandler()
        {
            _contaCorrenteService = ServiceLocator.Current.GetInstance<ContaCorrenteService>();
        }

        public Task Consume(ConsumeContext<IEmprestimo> context)
        {
            return Task.Run(() =>
            {
                var message = context.Message;
                var emprestimoCommand = new EmprestimoCommand(message.IdContaCorrente, message.IdEmprestimo, message.Valor);

                _contaCorrenteService.Execute(emprestimoCommand);
            });
        }
    }
}

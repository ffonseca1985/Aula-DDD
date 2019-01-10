using MassTransit;
using MovimentacoesGerais.Application.ContaCorrente;
using MovimentacoesGerais.Application.ContaCorrente.Commands;
using SharedKernel.InfraEstructure.Queue.Messages;
using System.Threading.Tasks;

namespace VendaQueue.ContaCorrente.EventHandlers
{
    public class AtualizarCompraCdbContaCorrenteEventHandler
        : IConsumer<IVenda>
    {
        ContaCorrenteService _contaCorrenteService;

        public AtualizarCompraCdbContaCorrenteEventHandler(ContaCorrenteService contaCorrenteService)
        {
            _contaCorrenteService = contaCorrenteService;
        }

        public Task Consume(ConsumeContext<IVenda> context)
        {
            var message = context.Message;
            var compraCommand = new ComprarCdbCommand(message.IdContaCorrente, message.CorrelationId, message.Valor);

            _contaCorrenteService.Execute(compraCommand);

            return Task.CompletedTask;
        }
    }
}

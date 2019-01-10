using MassTransit;
using SharedKernel.InfraEstructure.Queue.Messages;
using System.Threading.Tasks;

using SharedKernel.InfraEstructure.NoRelationalData;

namespace VendaQueue.Venda.EventHandlers
{
    public class AtualizarVendaQueryStackEventHandler
        : IConsumer<IVenda>
    {
        public Task Consume(ConsumeContext<IVenda> context)
        {
            var mensagem = new VendaCdb()
            {
                CorrelationId = context.Message.CorrelationId,
                Descricao = context.Message.Descricao,
                IdContaCorrente = context.Message.IdContaCorrente,
                Valor = context.Message.Valor
            };

            var store = new NoRelationalStore<VendaCdb>();
            return store.Add(mensagem, dataBase: "Venda", collectionName: "VendaCdb");
        }
    }
}

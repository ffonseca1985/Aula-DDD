using CQRSlite.Events;
using SharedKernel.InfraEstructure.Queue.Config;
using SharedKernel.InfraEstructure.Queue.Constants;
using SharedKernel.InfraEstructure.Queue.Messages;
using System;
using System.Threading.Tasks;
using Vendas.Events;

namespace Vendas.EventHandlers
{
    public class VendaEventHandler
        : IEventHandler<CDBVendidoEvent>
    {
        //Toda vez que uma venda for feita será disparada
        //um evento para um sistema que terá que ter esta informação
        public Task Handle(CDBVendidoEvent message)
        {
            //Neste caso iremos usar um sistema de mensageria para
            //fazer este trabalho.
            //Exemplo: RabbitMq
            // => Estrutura de publish e subscribe entre sistemas

            return Task.Run(() => {

                var bus = BusConfig.ConfigureBus();

                var uri = new Uri(RabbitMqConstants.RabbitMqUri + RabbitMqConstants.QueueVenda);
                var endpoint = bus.GetSendEndpoint(uri).Result;

                //Os consumidores de IVenda serão
                //os ouvintes deste commando/evento
                endpoint.Send<IVenda>(new
                {
                    CorrelationId = message.Id,
                    IdContaCorrente = message.IdContaCorrente,
                    Valor = message.Valor,
                    Descricao = message.DescricaoVenda
                });
            });
        }
    }
}

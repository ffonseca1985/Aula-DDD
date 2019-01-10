using SharedKernel.InfraEstructure.Queue.Config;
using SharedKernel.InfraEstructure.Queue.Constants;
using MassTransit;
using SharedKernel.InfraEstructure.Queue.Messages;
using System.Threading.Tasks;

namespace VendaQueue.App_Start
{
    public static class Bootstrap
    {
        public static void Initialize()
        {
            var bus = BusConfig.ConfigureBus(
                
                (cfg, host) =>
                {
                    cfg.ReceiveEndpoint(host, RabbitMqConstants.QueueVenda, h => {
                        h.Handler<IVenda>((context) =>
                        {
                            return Task.Run(() =>
                            {
                                context.Publish<IVenda>(new
                                {
                                    CorrelationId = context.Message.CorrelationId,
                                    IdContaCorrente = context.Message.IdContaCorrente,
                                    Valor = context.Message.Valor,
                                    Descricao = context.Message.Descricao
                                });
                            });
                        });
                    });
                }
            );
        }
    }
}

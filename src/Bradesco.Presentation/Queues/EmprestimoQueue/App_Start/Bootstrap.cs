using EmprestimoQueue.ContaCorrente.EventHandlers;
using MassTransit;
using SharedKernel.InfraEstructure.Queue.Config;
using SharedKernel.InfraEstructure.Queue.Constants;
using SharedKernel.InfraEstructure.Queue.Messages;
using System.Threading.Tasks;

namespace EmprestimoQueue.App_Start
{
    public static class Bootstrap
    {
        public static void Initialize()
        {
            var bus = BusConfig.ConfigureBus(

                (cfg, host) =>
                {
                    cfg.ReceiveEndpoint(host, RabbitMqConstants.QueueEmprestimo, h => {
                        h.Consumer<AtualizarEmprestimoContaCorrenteEventHandler>();
                    });
                }
            );

            bus.Start();
        }
    }
}

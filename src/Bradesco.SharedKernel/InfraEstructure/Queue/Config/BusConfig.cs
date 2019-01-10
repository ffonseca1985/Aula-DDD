namespace SharedKernel.InfraEstructure.Queue.Config
{
    using MassTransit;
    using MassTransit.RabbitMqTransport;
    using SharedKernel.InfraEstructure.Queue.Constants;
    using System;

    //Esta classe é responsavel por gerenciar
    //o fluxo de mensagens via fila entre contextos delimitados
    public class BusConfig
    {
        //usuario e senha
        public static IBusControl ConfigureBus(
            Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> execute = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(RabbitMqConstants.RabbitMqUri), hst =>
                {
                    hst.Username(RabbitMqConstants.UserName);
                    hst.Password(RabbitMqConstants.Password);
                });

                execute?.Invoke(cfg, host);
            });
        }
    }
}

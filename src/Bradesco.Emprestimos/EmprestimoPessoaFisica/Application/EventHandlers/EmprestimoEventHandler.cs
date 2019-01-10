using EmprestimoPessoaFisica.Application.Events;
using SharedKernel.InfraEstructure.Messages;
using SharedKernel.InfraEstructure.Queue.Config;
using SharedKernel.InfraEstructure.Queue.Constants;
using SharedKernel.InfraEstructure.Queue.Messages;
using System;

namespace EmprestimoPessoaFisica.Application.EventHandlers
{
    public class EmprestimoEventHandler
          :HandlerBase,  
          IHandlerMessage<EmprestimoFinalizadoEvent>
    {
        public void Handle(EmprestimoFinalizadoEvent message)
        {
            //coloco em uma Fila

            var bus = BusConfig.ConfigureBus();

            var uri = new Uri($"{RabbitMqConstants.RabbitMqUri}" + $"{RabbitMqConstants.QueueEmprestimo}");
            var endpoint = bus.GetSendEndpoint(uri).Result;

            //Os consumidores de IVenda serão
            //os ouvintes deste commando/evento
            endpoint.Send<IEmprestimo>(new
            {
                IdEmprestimo = message.IdEmprestimo,
                IdContaCorrente = message.IdContaCorrente,
                Valor = message.Valor
            });
        }
    }
}

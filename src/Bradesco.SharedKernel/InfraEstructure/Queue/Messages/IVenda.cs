using System;

namespace SharedKernel.InfraEstructure.Queue.Messages
{
    public interface IVenda
    {
        Guid CorrelationId { get; set; }
        Guid IdContaCorrente { get; set; }
        decimal Valor { get; set; }
        string Descricao { get; set; }
    }
}

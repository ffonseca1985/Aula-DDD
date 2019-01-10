using SharedKernel.InfraEstructure.Queue.Messages;
using System;

namespace VendaQueue.Venda.EventHandlers
{
    public class VendaCdb : IVenda
    {
        [MongoDB.Bson.Serialization.Attributes.BsonId()]
        public Guid CorrelationId { get; set; }

        public Guid IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}

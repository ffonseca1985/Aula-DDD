using CQRSlite.Events;
using System;

namespace Vendas.Events
{
    public class CDBCriadoEvent
        : IEvent
    {
        public CDBCriadoEvent(Guid id, string nome, decimal preco)
        {
            this.Nome = nome;
            this.Id = id;
            this.Preco = preco;
            this.TimeStamp = DateTimeOffset.Now;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public string Nome { get; private set; }
        public decimal Preco { get; private set; } 
    }
}

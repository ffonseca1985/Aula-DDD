using System;
using CQRSlite.Events;

namespace Vendas.Events
{
    //Um evento é algo que aconteceu, logo estará no passado
    public class CDBVendidoEvent
        : IEvent
    {
        public CDBVendidoEvent(Guid id, Guid idContaCorrente, decimal valor, string descricaoVenda)
        {
            this.Id = id;
            this.TimeStamp = DateTimeOffset.Now;
            this.IdContaCorrente = idContaCorrente;
            this.Valor = valor;
            this.DescricaoVenda = descricaoVenda;
        }

        //Quando enviamos uma mensagem para alguém precisamos informar no mínimo o Id do Agregado!
        public Guid Id { get; set; }

        //string Nome do produto Financeiro
        public string DescricaoVenda { get; set; }

        //Garantir o enfileiramento das mensagens
        public int Version { get; set; }

        //Data para questões de relatório, ordem, fila etc.
        public DateTimeOffset TimeStamp { get; set; }

        //São os dados necessários para enviar para os iteressados (outros contextos delimitados,
        //métodos etc).
        public Guid IdContaCorrente { get; private set; }
        public decimal Valor { get; private set; }
    }
}

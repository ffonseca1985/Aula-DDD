using CQRSlite.Domain;
using System;
using System.Collections.Generic;
using Vendas.Events;

namespace Vendas.DomainModel.Venda
{
    public class Venda : AggregateRoot
    {
        private Venda() {}

        public Venda(Guid id, Guid idContaCorrente)
        {
            //Definindo o Id de fora (via injeção fica mais fácil de controlar o que foi inserido)
            Id = id;
            this.IdContaCorrente = id;
            this.ItensVenda = new List<ItemVenda>();
            this.DataVenda = DateTime.Now;
            //Teremos que aplicar um evento para dizer que uma venda foi feita!.
            this.ApplyChange(new CDBVendidoEvent(this.Id, idContaCorrente, this.Total, "Venda Produtos Financeiros"));
        }

        public Guid IdContaCorrente { get; private set; }

        public List<ItemVenda> ItensVenda { get; private set; }

        public decimal Total { get { return this.GetTotal(); } }

        public DateTime DataVenda { get; private set; }

        public void AdicionarItem(CDB cdb, int qtde)
        {
            var item = new ItemVenda(cdb, qtde);
            this.ItensVenda.Add(item);
        }

        public void AdicionarDescontoItem(ItemVenda item, Desconto desconto)
        {
            item.AplicarDesconto(desconto);
        }

        public decimal GetTotal()
        {
            decimal total = 0;

            foreach (var item in ItensVenda)
            {
                total += item.GetTotal();
            }

            return total;
        }
    }
}

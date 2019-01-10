using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vendas.DomainModel.Venda
{
    public class ItemVenda
    {
        public ItemVenda(CDB cdb, int qtde)
        {
            this.Id = Guid.NewGuid();
            this.Cdb = cdb;
            this.Qtde = qtde;
            this.Desconto = new Desconto(); 
        }

        public Guid Id { get; private set; }
        public CDB Cdb { get; private set; }
        public Desconto Desconto { get; private set;}
        public int Qtde { get; private set; }

        public void AplicarDesconto(Desconto desconto)
        {
            this.Desconto = desconto;
        }

        public decimal GetTotal()
        {
            if (this.Desconto.UnidadeMedida == UnidadeMedida.porcentagem)
                return this.Qtde * this.Cdb.Preco.Valor * (1 - this.Desconto.Valor/100);

            return this.Qtde * this.Cdb.Preco.Valor  - this.Desconto.Valor;
        }
    }
}

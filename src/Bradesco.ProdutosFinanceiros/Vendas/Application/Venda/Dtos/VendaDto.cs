using System;

namespace Vendas.Application.Venda.Dtos
{
    public class VendaDto
    {
        public VendaDto(Guid idContaCorrente, Guid idVenda, 
            decimal total, DateTime dataVenda)
        {
            this.IdContaCorrente = idContaCorrente;
            this.IdVenda = IdVenda;
            this.Total = total;
            this.DataVenda = dataVenda;
        }

        public Guid IdContaCorrente { get; private set; }
        public Guid IdVenda { get; private set; }
        public decimal Total { get; private set; }
        public DateTime DataVenda { get; private set; }
    }
}

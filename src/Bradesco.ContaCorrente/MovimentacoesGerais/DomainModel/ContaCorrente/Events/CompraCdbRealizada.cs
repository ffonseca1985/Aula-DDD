using SharedKernel.InfraEstructure.Messages;
using System;

namespace MovimentacoesGerais.DomainModel.ContaCorrente.Events
{
    public class CompraCdbRealizada : Event
    {
        public CompraCdbRealizada(Guid idVenda, decimal valor)
        {
            this.IdVenda = IdVenda;
            this.Valor = valor;
        }

        public Guid IdVenda { get; private set; }
        public decimal Valor { get; private set; }
    }
}

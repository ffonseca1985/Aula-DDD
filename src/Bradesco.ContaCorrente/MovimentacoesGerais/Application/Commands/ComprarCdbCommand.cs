using SharedKernel.InfraEstructure.Messages;
using System;

namespace MovimentacoesGerais.Application.ContaCorrente.Commands
{
    public class ComprarCdbCommand
        : ICommand
    {
        public ComprarCdbCommand(Guid idContaCorrente,
            Guid idProdutoFinanceiro, decimal valor)
        {
            this.IdContaCorrente = idContaCorrente;
            this.IdProdutoFinanceiro = idProdutoFinanceiro;
            this.Valor = valor;
        }

        public Guid IdContaCorrente { get; private set; }
        public Guid IdProdutoFinanceiro { get; private set; }
        public decimal Valor { get; private set; }
        public int Versao { get; set; }
    }
}

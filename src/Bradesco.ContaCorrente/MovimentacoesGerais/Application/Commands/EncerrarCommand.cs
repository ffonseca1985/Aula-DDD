using SharedKernel.InfraEstructure.Messages;
using System;

namespace MovimentacoesGerais.Application.ContaCorrente.Commands
{
    public class EncerrarCommand
        : ICommand
    {
        public EncerrarCommand(Guid idContaCorrente,
            Guid idProdutoFinanceiro, 
            string motivo)
        {
            this.IdContaCorrente = IdContaCorrente;
            this.IdProdutoFinanceiro = idProdutoFinanceiro;
            this.Motivo = motivo;
        }

        public Guid IdContaCorrente { get; private set; }
        public Guid IdProdutoFinanceiro { get; private set; }
        public string Motivo { get; private set; }
        public int Versao { get; set; }
    }
}

using SharedKernel.InfraEstructure.Messages;
using System;

namespace MovimentacoesGerais.Application.ContaCorrente.Commands
{
    public class DepositarCommand
        : ICommand
    {
        public DepositarCommand(Guid idContaCorrente, decimal valor)
        {
            this.IdContaCorrente = idContaCorrente;
            this.Valor = valor;
        }

        public Guid IdContaCorrente { get; private set; }
        public decimal Valor { get; set; }
        public int Versao { get; set; }
    }
}

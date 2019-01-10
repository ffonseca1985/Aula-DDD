using SharedKernel.InfraEstructure.Messages;
using System;

namespace MovimentacoesGerais.Application.Commands
{
    public class SacarCommand :
        ICommand
    {
        public SacarCommand(Guid idContaCorrente, 
            decimal valor)
        {
            this.IdContaCorrente = idContaCorrente;
            this.Valor = valor;
        }

        public Guid IdContaCorrente { get; private set; }
        public decimal Valor { get; private set; }
        public int Versao { get; set; }
    }
}

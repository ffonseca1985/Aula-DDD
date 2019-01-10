using SharedKernel.InfraEstructure.Messages;
using System;

namespace MovimentacoesGerais.Application.Commands
{
    public class CriarCommand
        : ICommand
    {
        public CriarCommand()
        {

        }

        public CriarCommand(
            string numeroAgencia,
            Guid idCliente)
        {
            this.IdContaCorrente = Guid.NewGuid();
            this.NumeroConta = Guid.NewGuid().ToString();
            this.NumeroAgencia = numeroAgencia;
            this.IdCliente = idCliente;
        }

        public int Versao { get; set; }
        public Guid IdContaCorrente { get; private set; }
        public Guid IdCliente { get; private set; }
        public string NumeroAgencia { get; private set; }
        public string NumeroConta { get; private set; }
    }
}

using SharedKernel.DomainModel;
using SharedKernel.InfraEstructure.Messages;
using System;

namespace MovimentacoesGerais.DomainModel.Events
{
    //O nome do evento/acao será ContaCorrenteCriada (ver: class Evento)
    public class ContaCorrenteCriada
        : Event
    {
        public ContaCorrenteCriada(Guid idContaCorrente, Guid idCliente, 
            string numeroConta, string numeroAgencia )
        {
            this.IdContaCorrente = idContaCorrente;
            this.IdCliente = idCliente;
            this.NumeroConta = numeroConta;
            this.NumeroAgencia = numeroAgencia;
        }

        //Depois de um evento criado ele não pode ser modificado
        public Guid IdContaCorrente { get; private set; }
        public Guid IdCliente { get; private set; }
        public string NumeroConta { get; private set; }
        public string NumeroAgencia { get; private set; }
    }
}

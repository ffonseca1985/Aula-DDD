using System;
using System.Runtime.Serialization;

namespace ContaCorrenteServiceService.ContaCorrente
{
    [DataContract]
    public class ContaCorrente
    {
        public ContaCorrente(Guid idContaCorrente,
            string numeroConta, string numeroAgencia,
            Guid idCliente, decimal saldo)
        {
            this.IdContaCorrente = IdContaCorrente;
            this.NumeroConta = numeroConta;
            this.NumeroAgencia = numeroAgencia;
            this.IdCliente = IdCliente;
            this.Saldo = Saldo;
        }

        [DataMember]
        public Guid IdContaCorrente { get; private set; }

        [DataMember]
        public string NumeroConta { get; private set; }

        [DataMember]
        public string NumeroAgencia { get; private set; }

        [DataMember]
        public Guid IdCliente { get; private set; }

        [DataMember]
        public decimal Saldo { get; private set; }
    }
}
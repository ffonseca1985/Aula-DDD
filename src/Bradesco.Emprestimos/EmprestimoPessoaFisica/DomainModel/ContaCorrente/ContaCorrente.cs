using SharedKernel.DomainModel;
using System;

namespace EmprestimoPessoaFisica.DomainModel.ContaCorrente
{
    public class ContaCorrente : AggregateRoot
    {
        private ContaCorrente()
        {

        } 

        public ContaCorrente(Guid idContaCorrente, string numeroConta,
            string numeroAgencia, Guid idCliente, decimal saldo)
        {
            this.Id = idContaCorrente;
            this.NumeroConta = numeroConta;
            this.IdCliente = IdCliente;
            this.Saldo = saldo;
        }

        public Guid Id { get; set; }
        public string NumeroConta { get; private set; }
        public string NumeroAgencia { get; private set; }
        public Guid IdCliente { get; private set; }
        public decimal Saldo { get; private set; }
        
    }
}

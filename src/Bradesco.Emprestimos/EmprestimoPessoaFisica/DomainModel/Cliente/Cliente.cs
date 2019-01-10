using SharedKernel.DomainModel;
using System;

namespace EmprestimoPessoaFisica.DomainModel.Cliente
{
    public class Cliente
        : AggregateRoot
    {
        private Cliente()
        {

        }

        public Cliente(string cpf, string nome, Guid id)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.Id = id;
        }

        public string Cpf { get; set; }
        public string Nome { get; set; }

        public Guid Id { get; private set; }
    }
}

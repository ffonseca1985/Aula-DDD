using SharedKernel.DomainModel;
using System;

namespace EmprestimoPessoaFisica.DomainModel.EmprestimoGeral
{
    public class EmprestimoGeral : AggregateRoot
    {
        private EmprestimoGeral(){}

        public EmprestimoGeral(Guid idContaCorrente, decimal valor)
        {
            this.Id = Guid.NewGuid();
            this.Valor = valor;
            this.IdContaCorrente = idContaCorrente;
            this.Data = DateTime.Now;
        }

        public decimal Valor { get; private set; }
        public Guid IdContaCorrente { get; private set; }
        public DateTime Data { get; private set; }

        public SituacaoEmprestimo Situacao { get; set; }
        public Guid Id { get; private set; }
    }
}

using SharedKernel.InfraEstructure.Messages;
using System;

namespace EmprestimoPessoaFisica.Application.Events
{
    public class EmprestimoFinalizadoEvent : Event
    {
        public EmprestimoFinalizadoEvent(Guid idEmprestimo,
            Guid idContaCorrente, decimal valor)
        {
            this.IdEmprestimo = idEmprestimo;
            this.IdContaCorrente = idContaCorrente;
            this.Valor = valor;
        }

        public Guid IdEmprestimo { get; private set; }
        public Guid IdContaCorrente { get; private set; }
        public decimal Valor { get; private set; }
    }
}

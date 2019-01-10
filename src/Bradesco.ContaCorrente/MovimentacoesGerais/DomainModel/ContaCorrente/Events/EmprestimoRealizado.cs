using SharedKernel.InfraEstructure.Messages;
using System;

namespace MovimentacoesGerais.DomainModel.ContaCorrente.Events
{
    public class EmprestimoRealizado : Event
    {
        public EmprestimoRealizado(Guid idEmprestimo, decimal valor)
        {
            this.IdEmprestimo = idEmprestimo;
            this.Valor = valor;
        }

        public Guid IdEmprestimo { get; private set; }
        public decimal Valor { get; private set; }
    }
}

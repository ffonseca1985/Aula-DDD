using SharedKernel.InfraEstructure.Messages;
using System;

namespace MovimentacoesGerais.Application.ContaCorrente.Commands
{
    public class EmprestimoCommand
        : ICommand
    {
        public EmprestimoCommand(Guid idContaCorrente,  
            Guid idEmprestimo, decimal valor)
        {
            this.IdContaCorrente = idContaCorrente;
            this.IdEmprestimo = idEmprestimo;
            this.Valor = valor;            
        }

        public Guid IdEmprestimo { get; private set; }
        public Guid IdContaCorrente { get; private set; }
        public decimal Valor { get; private set; }
        public int Versao { get; set; }
    }
}

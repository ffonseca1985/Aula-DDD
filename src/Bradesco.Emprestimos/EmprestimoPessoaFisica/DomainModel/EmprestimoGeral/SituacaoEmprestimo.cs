using System.Runtime.InteropServices;

namespace EmprestimoPessoaFisica.DomainModel.EmprestimoGeral
{
    //Objeto de Valor
    public class SituacaoEmprestimo
    {
        private SituacaoEmprestimo(){}

        public SituacaoEmprestimo(StatusEmprestimo status, [Optional] string motivo)
        {
            this.Status = status;
            this.Motivo = motivo;
        }

        public StatusEmprestimo Status { get; private set; }
        public string Motivo { get; private set; }
    }

    public enum StatusEmprestimo
    {
        Aprovado,
        Rejeitado
    }
}

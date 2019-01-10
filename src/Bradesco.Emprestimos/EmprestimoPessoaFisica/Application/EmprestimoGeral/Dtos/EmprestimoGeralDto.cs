using System;

namespace EmprestimoPessoaFisica.Application.EmprestimoGeral.Dtos
{
    public class EmprestimoGeralDto
    {
        public EmprestimoGeralDto(Guid idContaCorrente, decimal valor, DateTime dataEmprestimo)
        {
            this.IdContaCorrente = idContaCorrente;
            this.Valor = valor;
            this.DataEmprestimo = dataEmprestimo;
        }

        public Guid IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataEmprestimo { get; set; }
    }
}

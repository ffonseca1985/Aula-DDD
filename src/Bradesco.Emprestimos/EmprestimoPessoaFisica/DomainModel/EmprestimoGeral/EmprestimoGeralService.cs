using EmprestimoPessoaFisica.ClienteServiceReference;
using EmprestimoPessoaFisica.ContaCorrenteServiceReference;
using System;

namespace EmprestimoPessoaFisica.DomainModel.EmprestimoGeral
{
    public class EmprestimoGeralService
    {
        ContaCorrenteServiceClient _contaCorrenteClient;       

        public EmprestimoGeralService()
        {
            _contaCorrenteClient = new ContaCorrenteServiceClient();
        }
        
        //Regra generica para validar se o cliente é capaz de fazer o emprestimo
        public SituacaoEmprestimo AnalisarEmprestimoGeral(Guid idContaCorrente, decimal valorEmprestimo)
        {
            var contaCorrente = _contaCorrenteClient.Get(idContaCorrente);

            if (contaCorrente.Saldo > valorEmprestimo)
                return new SituacaoEmprestimo(StatusEmprestimo.Aprovado);

            return new SituacaoEmprestimo(StatusEmprestimo.Rejeitado);
        }
    }
}

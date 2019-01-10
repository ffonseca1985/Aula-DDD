using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Pacote muito legal para usar e estudar!!
using CQRSlite;
using CQRSlite.Commands;

namespace Vendas.Commands
{
    //- Comando é algo de "tela" que esta acontecendo 
    //agora!!

    //- Comando é um classe DTO que tem os elementos
    //suficientes para executar tal ação.

    // - Comando seria um método que foi abstraido para uma classe.
    public class VenderCDBCommand : ICommand
    {
        public VenderCDBCommand(Guid idProdutoFinanceiro,
            Guid IdContaCorrente, decimal desconto)
        {
            this.IdProdutoFinanceiro = idProdutoFinanceiro;
            this.IdContaCorrente = IdContaCorrente;
            this.Desconto = desconto;
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public Guid IdProdutoFinanceiro { get; private set; }
        public Guid IdContaCorrente { get; private set; }
        public decimal Desconto { get; private set; }

        //Lembra do controle de evento???
        //O CqrsLite já trás implementado!
        public int ExpectedVersion { get; set; }
    }
}

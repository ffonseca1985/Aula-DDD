using System;

namespace SistemaBancarioSiteWeb.Areas.Emprestimos.Models
{
    public class EmprestimoViewModel
    {
        public decimal Valor { get; set; }
        public Guid IdContaCorrente { get; set; }
        public DateTime Data { get; set; }
        //public string Situacao { get; set; }
    }
}
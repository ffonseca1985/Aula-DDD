using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaBancarioSiteWeb.Areas.Vendas.Models
{
    public class CriarVendaViewModel
    {
        [Required(ErrorMessage = "Campo não informado")]
        [Display(Name = "Produto Financeiro")]
        public Guid IdProdutoFinanceiro { get; set; }

        [Required(ErrorMessage = "Campo não informado")]
        [Display(Name = "Conta Corrente")]
        public Guid IdContaCorrente { get; set; }
    }
}
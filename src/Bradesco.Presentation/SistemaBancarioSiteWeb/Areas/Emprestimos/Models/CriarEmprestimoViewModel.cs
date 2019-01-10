using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaBancarioSiteWeb.Areas.Emprestimos.Models
{
    public class CriarEmprestimoViewModel
    {
        [Required(ErrorMessage = "Campo não informado")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo não informado")]
        public Guid IdContaCorrente { get; set; }
    }
}
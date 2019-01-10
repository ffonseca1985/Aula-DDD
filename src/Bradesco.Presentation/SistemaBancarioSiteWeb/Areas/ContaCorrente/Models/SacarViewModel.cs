using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaBancarioSiteWeb.Areas.ContaCorrente.Models
{
    public class SacarViewModel
    {
        [Required(ErrorMessage = "Campo não informado")]
        public Guid IdContaCorrente { get; set; }

        [Required(ErrorMessage = "Campo não informado")]
        public decimal Valor { get; set; }
    }
}
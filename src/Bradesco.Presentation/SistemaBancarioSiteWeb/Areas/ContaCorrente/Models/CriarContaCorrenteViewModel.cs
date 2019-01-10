using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaBancarioSiteWeb.Areas.ContaCorrente.Models
{
    public class CriarContaCorrenteViewModel
    {
        [Required(ErrorMessage = "Campo não informado")]
        public Guid IdCliente { get; set; }

        [Required(ErrorMessage = "Campo não informado")]
        public string NumeroAgencia { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaBancarioSiteWeb.Areas.Acessos.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "Código")]
        public Guid IdCliente { get; set; }
        public string  Nome { get; set; }
        public string Cpf { get; set; }
    }
}
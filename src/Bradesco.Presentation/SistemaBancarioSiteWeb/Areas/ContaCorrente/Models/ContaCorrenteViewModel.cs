using System;

namespace SistemaBancarioSiteWeb.Areas.ContaCorrente.Models
{
    public class ContaCorrenteViewModel
    {
        public Guid IdContaCorrente { get; set; }
        public Guid IdCliente { get; set; }
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }
        public decimal Saldo { get; set; }
    }
}
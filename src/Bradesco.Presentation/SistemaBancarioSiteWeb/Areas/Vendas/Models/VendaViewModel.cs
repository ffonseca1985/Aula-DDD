using System;

namespace SistemaBancarioSiteWeb.Areas.Vendas.Models
{
    public class VendaViewModel
    {
        public Guid IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}
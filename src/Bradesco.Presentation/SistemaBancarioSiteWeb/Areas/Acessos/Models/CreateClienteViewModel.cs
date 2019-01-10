using System.ComponentModel.DataAnnotations;

namespace SistemaBancarioSiteWeb.Areas.Acessos.Models
{
    public class CreateClienteViewModel
    {
        [Required(ErrorMessage ="Campo não informado")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo não informado")]
        public string NomeMae { get; set; }

        [Required(ErrorMessage = "Campo não informado")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo não informado")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo não informado")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo não informado")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo não informado")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo não informado")]
        public string Estado { get; set; }
    }
}
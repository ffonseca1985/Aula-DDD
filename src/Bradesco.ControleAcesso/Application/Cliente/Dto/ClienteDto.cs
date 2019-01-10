using System;

namespace ControleAcesso.Application.Cliente.Dto
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string NomeMae { get; set; }
        public string Cpf { get; set; }
        public string Descricao { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public String Estado { get; set; }
    }
}

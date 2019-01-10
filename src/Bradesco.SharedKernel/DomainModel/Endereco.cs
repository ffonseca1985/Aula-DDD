using System.Runtime.InteropServices;

namespace SharedKernel.DomainModel
{
    public class Endereco
    {
        private Endereco() { }

        public Endereco(string descricao,  string numero, string bairro,
            string cidade, [Optional] Estado estado)
        {
            this.Descricao = descricao;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Estado = estado;
        }

        public string Descricao { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public Estado Estado { get; private set; }
    }
}

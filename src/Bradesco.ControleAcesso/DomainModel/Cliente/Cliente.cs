using SharedKernel.DomainModel;
using System;

namespace ControleAcesso.DomainModel.Cliente
{
    public class Cliente : AggregateRoot
    {
        private Cliente() { }

        private Cliente(string nome, string cpf, string nomeMae)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Cpf = cpf;
            this.NomeMae = nomeMae;
        }

        public string Nome { get; private set; }
        public string NomeMae { get; private set; }
        public string Cpf { get; private set; }
        public Endereco Endereco { get; private set; }

        public Guid Id { get; private set; }

        public class UsuarioFactory
        {
            public UsuarioFactory(){}

            public static Cliente Create(string nome, string cpf, string nomeMae,
                string descricao, string numero, string bairro, string cidade, Estado estado)
            {
                //Builder
                var usuario = CreateCliente(nome, cpf, nomeMae);
                usuario.Endereco = CreateEndereco(descricao, numero, bairro, cidade, estado);

                return usuario;
            }

            public static Cliente CreateSemEndereco(string nome, string cpf, string nomeMae)
            {
                //Builder
                var usuario = CreateCliente(nome, cpf, nomeMae);
                usuario.Endereco = CreateEnderecoNull();

                return usuario;
            }

            private static Cliente CreateCliente(string nome, string cpf, string nomeMae)
            {
                return new Cliente(nome, cpf, nomeMae);
            }

            private static Endereco CreateEndereco(string descricao, string numero, string bairro,
                string cidade, Estado estado)
            {
                return new Endereco(descricao, numero, bairro, cidade, estado);
            }

            private static Endereco CreateEnderecoNull()
            {
                return new Endereco(string.Empty, string.Empty, string.Empty, string.Empty);
            }
        }
    }
}

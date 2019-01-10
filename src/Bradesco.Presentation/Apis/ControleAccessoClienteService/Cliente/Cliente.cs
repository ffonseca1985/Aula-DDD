using System;
using System.Runtime.Serialization;

namespace ControleAccessoClienteService.Cliente
{
    [DataContract]
    public class Cliente
    {
        public Cliente(Guid id, string cpf, string nome)
        {
            this.Id = id;
            this.Cpf = cpf;
            this.Nome = nome;
        }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string Cpf { get; private set; }

        [DataMember]
        public string Nome { get; private set; }
    }
}
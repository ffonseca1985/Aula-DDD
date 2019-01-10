using System;

namespace VendasQueryStack.Application.Cliente
{
    public class ClienteDto
    {
        //Este cliente foi criado no contexto
        //anterior, logo não posso fazer nada
        //Apenas Selecionar
        public ClienteDto(string cpf, string nome)
        {
            this.Cpf = cpf;
            this.Nome = nome;
        }
        
        public string Cpf { get; private set; }
        public string Nome { get; private set; }
    }
}

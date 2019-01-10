using CQRSlite.Domain;
using System;
using Vendas.Events;

namespace Vendas.DomainModel.Venda
{
    public class CDB : AggregateRoot
    {
        private CDB() {}

        public CDB(string nome, Preco preco)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.Id = Guid.NewGuid();

            //Toda vez que um CDB for criando um evento será disparado
            //Logo precisamos construir os ouvintes!!!
            //Estamos construindo uma estrutura de publish e subcribe
            ApplyChange(new CDBCriadoEvent(this.Id, this.Nome, this.Preco.Valor));
        }

        public string Nome { get; private set; }
        public Preco Preco { get; private set; }
    }
}

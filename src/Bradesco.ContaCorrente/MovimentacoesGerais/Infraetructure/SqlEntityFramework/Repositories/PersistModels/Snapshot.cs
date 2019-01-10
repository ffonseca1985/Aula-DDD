using System;

namespace MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories.PersistModels
{
    public abstract class Snapshot
    {
        public Guid Id { get; protected set; }
        public DateTime DataCriacao { get;  protected set; }
        public Guid AggregateId { get; protected set; }
        public int VersaoAtual { get; protected set; }
        public int VersaoAnterior { get; protected set; }

    }
}

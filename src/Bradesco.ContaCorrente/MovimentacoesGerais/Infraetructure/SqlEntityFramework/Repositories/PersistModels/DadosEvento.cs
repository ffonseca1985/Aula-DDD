using System;

namespace MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories.PersistModels
{
    public class DadosEvento
    {
        private DadosEvento() { }

        public DadosEvento(Guid aggregateId, string eventos, int versao, DateTime data)
        {
            this.Id = Guid.NewGuid();
            this.AggregateId = aggregateId;
            this.Eventos = eventos;
            this.Data = data;
        }

        public Guid Id { get; set; }
        public Guid AggregateId { get; private set; }
        //Json contento os eventos que aconteceram com a conta corrente
        //em determinado fluxo 
        public string Eventos { get; private set; }
        public int Versao { get; private set; }
        public DateTime Data { get; private set; }
    }
}

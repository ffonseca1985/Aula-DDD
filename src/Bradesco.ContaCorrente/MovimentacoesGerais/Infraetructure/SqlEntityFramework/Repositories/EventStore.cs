using System;
using System.Collections.Generic;
using System.Linq;

namespace MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories
{
    using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Context;
    using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories.PersistModels;
    using Newtonsoft.Json;
    using SharedKernel.InfraEstructure.Messages;

    public class EventStore<T> : IEventStoreWithSnapshot<T>
        where T : Snapshot
    {
        MovimentacoesGeraisContext _movimentacoesGeraisContext;

        public EventStore(MovimentacoesGeraisContext movimentacoesGeraisContext)
        {
            _movimentacoesGeraisContext = movimentacoesGeraisContext;
        }

        public List<DadosEvento> GetAll(Guid aggregateId, int posicao = 0)
        {
            var eventos = _movimentacoesGeraisContext.DadosEvento.Where(x => x.AggregateId == aggregateId && x.Versao >= posicao);
            return eventos.ToList();
        }

        public T GetSnapshot(Guid aggregateId)
        {
            return this._movimentacoesGeraisContext.Set<T>().OrderByDescending(x => x.VersaoAtual).FirstOrDefault();
        }

        public void Save(Guid aggregateId, IEnumerable<Event> eventos, int versao, DateTime data)
        {
            string eventoJson = JsonConvert.SerializeObject(eventos);
            var dadosEvento = new DadosEvento(aggregateId, eventoJson, versao, data);

            this._movimentacoesGeraisContext.DadosEvento.Add(dadosEvento);
            this._movimentacoesGeraisContext.SaveChanges();
        }

        public void SaveSnapshot(T snapshot)
        {
            this._movimentacoesGeraisContext.Set<T>().Add(snapshot);
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            this._movimentacoesGeraisContext.SaveChanges();
        }
    }
}

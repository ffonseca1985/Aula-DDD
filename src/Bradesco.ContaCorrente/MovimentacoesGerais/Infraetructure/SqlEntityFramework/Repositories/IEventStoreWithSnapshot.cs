using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories.PersistModels;
using SharedKernel.InfraEstructure.Messages;
using System;
using System.Collections.Generic;

namespace MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories
{
    public interface IEventStoreWithSnapshot<T>
        where T : Snapshot

    {
        void Save(Guid aggregateId, IEnumerable<Event> eventos, int versao, DateTime data);
        void SaveSnapshot(T snapshot);
        
        //Posicao Atual a partir de um snapshot
        T GetSnapshot(Guid aggregateId);

        //Buscar tudo e compilar depois
        List<DadosEvento> GetAll(Guid aggregateId, int posicao = 0);
    }
}

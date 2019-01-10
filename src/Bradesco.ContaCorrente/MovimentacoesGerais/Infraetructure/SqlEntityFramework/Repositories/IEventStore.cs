
using SharedKernel.DomainModel;
using SharedKernel.InfraEstructure.Messages;
using System;
using System.Collections.Generic;

namespace MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories
{
    public interface IEventStore
    {
        void Salvar(Guid idAgregado, IEnumerable<Event> eventos, int versaoEsperada);
        IEnumerable<Event> BuscarEventoPor(Guid idAgregado, int inicio = 0);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using SharedKernel.InfraEstructure.Messages;
using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories.PersistModels;

namespace MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories
{
    public class EventStoreInMemory
        : IEventStore
    {
        //Vamos supor que dados é os dados do banco de dados
        //O que temos no banco???
        //Resp.: Temos um modelo de persistencia chamado DadosEvento!!
        private readonly Dictionary<Guid, List<DadosEventoInMemory>> dados
                = new Dictionary<Guid, List<DadosEventoInMemory>>();

        public void Salvar(Guid idAgregado, IEnumerable<Event> eventos, int versaoEsperada)
        {
            List<DadosEventoInMemory> eventosArmazenados = null;

            //O item Dados é o nosso banco de dados!!!

            if (!dados.TryGetValue(idAgregado, out eventosArmazenados))
            {
                eventosArmazenados = new List<DadosEventoInMemory>();
                dados.Add(idAgregado, eventosArmazenados);
            }

            foreach (var @evento in eventos)
            {
                eventosArmazenados.Add(new DadosEventoInMemory(idAgregado, @evento, ++versaoEsperada));
            }
        }

        public IEnumerable<Event> BuscarEventoPor(Guid idAgregado, int inicio = 0)
        {
            return dados[idAgregado].Select(e => e.Evento).Skip(inicio);
        }        
    }
}

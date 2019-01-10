using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using CQRSlite.Bus;

namespace Vendas.EventStore
{
    //Responsável por gerenciar o ciclo de vida dos eventos
    //contidos no(s) aggregates
    public class InMemoryEventStore
        : IEventStore
    {
        //Meus eventos que serão adicionados por demanda e ficarão em memória
        private readonly Dictionary<Guid, List<IEvent>> _inMemoryBd = 
            new Dictionary<Guid, List<IEvent>>();

        private InProcessBus _publisher;

        //Como registramos o InProcessBus no serviceLocator podemos selecionar a instancia 
        //via construtor
        public InMemoryEventStore(InProcessBus publisher)
        {
            _publisher = publisher;
        }

        public Task<IEnumerable<IEvent>> Get(
            Guid aggregateId, 
            int fromVersion, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => {

                List<IEvent> events;

                //Para mais detalhes ver projeto eventsourcing!!!
                _inMemoryBd.TryGetValue(aggregateId, out events);
                return events?.Where(x=>x.Version > fromVersion) ?? new List<IEvent>();
            });
        }

        public Task Save(IEnumerable<IEvent> events, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            //No salvar vamos colocar os eventos na memoria e vamos publicar os eventos
            //para os assinantes
            return Task.Run(() => {

                foreach (var @event in events)
                {
                    List<IEvent> list;
                    this._inMemoryBd.TryGetValue(@event.Id, out list);

                    if (list == null)
                    {
                        list = new List<IEvent>();
                        _inMemoryBd.Add(@event.Id, list);
                    }

                    list.Add(@event);
                    _publisher.Publish(@event);
                }
            });
        }
    }
}

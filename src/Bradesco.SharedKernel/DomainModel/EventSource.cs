using SharedKernel.InfraEstructure.Messages;
using System.Collections.Generic;

namespace SharedKernel.DomainModel
{
    //NA minha opnião toda classe deveria ter uma
    //lista de eventos
    //O que ferra é o EF!!
    public abstract class EventSource
    {
        //Lista de Eventos na memória
        private List<Event> _eventos = new List<Event>();

        //versão inicial é a versão do banco
        public int VersaoInicial { get; protected set; }

        //versão inicial é a versão corrente
        public int VersaoAtual { get; protected set; }


        public List<Event> Eventos
        {
            get
            {
                return this._eventos;
            }
        }

        //Posso ter duas cituações para disparar o meu evento:
        //1 - quando for montar o saldo atual
        //2 - para enviar para o banco (fonte de evento - event sourcing)
        public virtual void DispararEvento(Event evento, bool eventoNovo = true)
        {
            ((dynamic)this).Aplicar((dynamic)evento);

            //Modifando a versão atual
            this.VersaoAtual++;

            if (eventoNovo)
                this._eventos.Add(evento);
        }
    }
}

using SharedKernel.DomainModel;
using SharedKernel.InfraEstructure.Messages;
using System;

namespace MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories.PersistModels
{
    public class DadosEventoInMemory
    {
        public DadosEventoInMemory(Guid idAgregado, Event evento, int versao)
        {
            this.IdAgregado = idAgregado;
            this.Evento = evento;
            this.Versao = versao;
        }

        public Guid IdAgregado { get; private set; }
        public Event Evento { get; private set; }
        public int Versao { get; private set; }
    }
}

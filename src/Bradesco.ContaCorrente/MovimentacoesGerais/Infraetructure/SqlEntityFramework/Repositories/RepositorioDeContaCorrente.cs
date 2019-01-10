using MovimentacoesGerais.DomainModel.ContaCorrente;
using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories.PersistModels;
using System;
using System.Linq;

namespace MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories
{
    public class RepositorioDeContaCorrente
        : IRepositorio<ContaCorrente>
    {
        private readonly EventStore<PosicaoAtualContaCorrente> _eventStore;

        public RepositorioDeContaCorrente(EventStore<PosicaoAtualContaCorrente> eventStore)
        {
            _eventStore = eventStore;
        }

        //Buscar o ultimo estado da corrente
        public ContaCorrente BuscarPor(Guid id)
        {
            var contaCorrente = new ContaCorrente();

            //Verificar se tem snapshop 
            //se tiver busco a partir dele

            var snapshot = _eventStore.GetSnapshot(id);
            if (snapshot != null)
                contaCorrente = new ContaCorrente(snapshot);

            var dadoEvento = _eventStore.GetAll(id, contaCorrente.VersaoAtual);

            if (dadoEvento.Any())
            {
                contaCorrente.CarregarPorListaEvento(dadoEvento);
                contaCorrente.Eventos.Clear();
                return contaCorrente;
            }
            return null;
        }

        public void Salvar(ContaCorrente entidade)
        {
            _eventStore.Save(entidade.Id, entidade.Eventos, entidade.VersaoInicial, DateTime.Now);
        }
    }
}

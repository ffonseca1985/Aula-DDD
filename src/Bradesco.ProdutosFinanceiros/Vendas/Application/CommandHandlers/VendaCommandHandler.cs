using CQRSlite.Commands;
using CQRSlite.Domain;
using System.Threading.Tasks;
using Vendas.Commands;
using Vendas.DomainModel.Venda;
using Vendas.Infraestructure.SqlEntityFramework.Repositories;

namespace Vendas.CommandHandlers
{
    public class VendaCommandHandler
        : ICommandHandler<VenderCDBCommand>
    {
        //Quando uma ação é disparada, os eventos são
        //guardados dentro do agregado e usando o objeto session
        //conseguimos disparar os eventos para quem assinar!!!
        Session _sessao;
        RepositoryBase<Venda> _vendaRepository;

        public VendaCommandHandler(Session sessao,
            RepositoryBase<Venda> vendaRepository)
        {
            //Quando criamos uma estrutura de eventos
            //temos que garantir que só quando tudo ocorrer bem é que os eventos serão disparados
            _sessao = sessao;
            _vendaRepository = vendaRepository;
        }

        public Task Handle(VenderCDBCommand message)
        {
                //O que este cara faz???
                //Resp: Inserir no banco, fazer a regra de negócio de vender command
                //Resp: E ainda podemos disparar alguns eventos!!!

                Venda venda = new Venda(message.Id, message.IdContaCorrente);
                
                //TODO pegar o id do CDB e adicionar na venda
                //Nunca mude 2 aggregates de um vez!!
                //Sempre relacione seus objetos pelo Id

                //suponha que tudo deu certo!!!
                _sessao.Add(venda);
                //Após garantir que tudo deu ok
                //eu dou um commit!!!

                //suponha uma regra qquer.
                _vendaRepository.Add(venda);
                _sessao.Commit();

            return Task.CompletedTask;
        }
    }
}

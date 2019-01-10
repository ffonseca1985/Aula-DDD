using SharedKernel.DomainModel;
using System;

namespace MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories
{
    public interface IRepositorio<T>
        where T : AggregateRoot, 
                  new() //Obrigatório ter um construtor publico e sem parametro
    {
        void Salvar(T entidade);
        T BuscarPor(Guid id);
    }
}

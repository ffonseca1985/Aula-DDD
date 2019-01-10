using SharedKernel.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SharedKernel.InfraEstructure.DomainModel
{
    public interface IRepositoryBase<T>
        where T : AggregateRoot
    {
        void Add(T obj);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);
        T FindById(params object[] keys);
        void Remove(T obj);
        void Update(T obj);
    }
}

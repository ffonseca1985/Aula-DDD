using ControleAcesso.Infraestructure.SqlEntityFramework.Contexts;
using SharedKernel.DomainModel;
using SharedKernel.InfraEstructure.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ControleAcesso.Infraestructure.SqlEntityFramework.Repository
{
    public class RepositoryBase<T>
        : IRepositoryBase<T> where T : class, AggregateRoot
    {
        private ControleAcessoContext _context;

        public RepositoryBase(ControleAcessoContext context)
        {
            _context = context;
        }

        public void Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }

        public T FindById(params object[] keys)
        {
            return _context.Set<T>().Find(keys);
        }

        public void Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

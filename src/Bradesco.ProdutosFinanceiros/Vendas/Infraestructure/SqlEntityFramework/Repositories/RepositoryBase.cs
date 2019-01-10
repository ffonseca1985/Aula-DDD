using CQRSlite.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Vendas.Infraestructure.SqlEntityFramework.Contexts;

namespace Vendas.Infraestructure.SqlEntityFramework.Repositories
{
    public class RepositoryBase<T>
        where T : AggregateRoot
    {
        private VendaContext _context;
        public RepositoryBase(VendaContext context)
        {
            _context = context;
        }

        public void Add(T obj)
        {
            _context.Set<T>().Add(obj);


            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsEnumerable();
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

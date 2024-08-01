using Microsoft.EntityFrameworkCore;
using Stefanini.Order.Domain;
using Stefanini.Order.Domain.Interfaces;
using Stefanini.Order.Infra.Context;

namespace Stefanini.Order.Infra.Common
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        protected readonly EfCore _context;
        protected readonly DbSet<T> Entity = null;

        public RepositoryBase(EfCore ef)
        {
            _context = ef;
            Entity = _context.Set<T>();

        }
        public T Add(T entity)
        {
            Entity.Add(entity);
            _context.SaveChanges();
            return entity;

        }

        public List<T> Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return Get();
        }

        public T Detach(T entity)
        {
            foreach (var entry in _context.ChangeTracker.Entries().ToList())
                _context.Entry(entry.Entity).State = EntityState.Detached;

            return entity;
        }

        public List<T> Get()
        {
             return Entity.ToList();
        }

        public T GetById(int id)
        { 
            return Entity.Find(id);
        }

        public T Update(int id, T entity)
        {
           entity.Id = id;
           _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}

using Stefanini.Order.Domain;

namespace Stefanini.Order.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T Add(T entity);
        List<T> Get();
        T Detach(T entity);
        List<T> Delete(T entity);
        T GetById(int id);
        T Update(int id, T entity);
    }
}

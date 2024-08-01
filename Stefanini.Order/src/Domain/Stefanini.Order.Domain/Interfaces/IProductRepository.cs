namespace Stefanini.Order.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Domain.Entites.Product>, IDisposable
    {
        Task<Domain.Entites.Product> GetProduct(int productId);
    }
}

namespace Stefanini.Order.Domain.Interfaces
{
    public interface IOrderItemRepository : IRepository<Domain.Entites.OrderItem>, IDisposable
    {
    }
}

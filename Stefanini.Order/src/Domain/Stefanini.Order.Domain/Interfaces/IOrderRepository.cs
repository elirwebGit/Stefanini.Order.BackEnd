using System.Runtime.InteropServices;

namespace Stefanini.Order.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Domain.Entites.Order>, IDisposable
    {
        Task<Domain.Entites.Order> GetOrderId(int orderId);
        Task<List<Domain.Dapper.OrderList>> GetOrder([Optional] int orderId);

    }
}

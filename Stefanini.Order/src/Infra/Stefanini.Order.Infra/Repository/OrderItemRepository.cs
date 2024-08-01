using Stefanini.Order.Domain.Interfaces;
using Stefanini.Order.Infra.Context;

namespace Stefanini.Order.Infra.Repository
{
    public class OrderItemRepository : Common.RepositoryBase<Domain.Entites.OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(EfCore ef) : base(ef)
        {
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

using Stefanini.Order.Domain.Interfaces;


namespace Stefanini.Order.Infra.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rolback();
        IOrderRepository Order { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IProductRepository ProductRepository { get; }


    }
}

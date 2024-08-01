using Stefanini.Order.Domain.Interfaces;

namespace Stefanini.Order.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.EfCore _repository;

        public UnitOfWork(Context.EfCore context)
        {
            _repository = context;
            Order = new Repository.OrderRepository(_repository);
            OrderItemRepository = new Repository.OrderItemRepository(_repository);
            ProductRepository = new Repository.ProductRepository(_repository);


        }
        public IOrderItemRepository OrderItemRepository { get; private set; }

        public IOrderRepository Order { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public void Commit()
        {
            _repository.SaveChanges();
        }

        public void Rolback()
        {
            _repository.Database.RollbackTransaction();
        }
    }
}

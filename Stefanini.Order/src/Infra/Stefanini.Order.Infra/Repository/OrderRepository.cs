using Dapper;
using Stefanini.Order.Domain.Interfaces;
using Stefanini.Order.Infra.Context;
using System.Runtime.InteropServices;
using System.Text;

namespace Stefanini.Order.Infra.Repository
{
    public class OrderRepository : Common.RepositoryBase<Domain.Entites.Order>, IOrderRepository
    {
        public OrderRepository(EfCore ef) : base(ef)
        {
        }

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<List<Domain.Dapper.OrderList>> GetOrder(int orderId = 0)
        {
            var cn = _context.Connection;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT pedido.OrderId PedidoId,CustomerName nomeCliente,CustomerEmail emailCliente,Paid pago, ");
            sql.Append(" item.[Value] valorTotal, item.OrderItemId ItemId,item.ProductId idProduto,product.ProductName nomeProduto, product.[Value] valorUnitario, item.Quantity quantidade");
            sql.Append(" FROM [Order] pedido ");
            sql.Append(" inner join OrderItem item on item.OrderId = pedido.OrderId ");
            sql.Append(" inner join Product product on Product.ProductId = item.ProductId ");
            sql.Append(" where  pedido.Active = 1 ");
            if (orderId != 0) {
                sql.Append(" and  pedido.OrderId = @orderId ");

            }
            var result = await Task.FromResult(cn.Query<Domain.Dapper.OrderList>(sql.ToString(),new { OrderId = orderId }));
            return result.ToList();
        }

        public async Task<Domain.Entites.Order> GetOrderId(int orderId)
        {
            var cn = _context.Connection;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT OrderId,CustomerName,CustomerEmail,Paid  FROM [Order] ");
            sql.Append("where OrderId = @orderId");
            var result = await Task.FromResult(cn.QueryFirstOrDefault<Domain.Entites.Order>(sql.ToString(), new { OrderId = orderId }));
            return result!;
        }
    }
}

using Dapper;
using Stefanini.Order.Domain.Entites;
using Stefanini.Order.Domain.Interfaces;
using Stefanini.Order.Infra.Context;
using System.Text;

namespace Stefanini.Order.Infra.Repository
{
    public class ProductRepository : Common.RepositoryBase<Domain.Entites.Product>, IProductRepository
    {
        public ProductRepository(EfCore ef) : base(ef)
        {
        }
        

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<Product> GetProduct(int productId)
        {
            var cn = _context.Connection;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ProductId,ProductName,[Value]  FROM Product where ProductId = @productId");
            var result = await Task.FromResult(cn.QueryFirstOrDefault<Product>(sql.ToString(), new { productId = productId }));
            return result!;
        }
    }
}

using System.Data;

namespace Stefanini.Order.Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        public IDbConnection Connection { get; }
    }
}

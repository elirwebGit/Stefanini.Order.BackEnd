using Microsoft.EntityFrameworkCore;

namespace Stefanini.Order.Util
{
    public class Connection : DbContext
    {
        public Connection(DbContextOptions<Connection> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(WebConfig.GETSTRINCONNECTION);
        }
    }
}

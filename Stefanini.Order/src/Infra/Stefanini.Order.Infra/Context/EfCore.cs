using Microsoft.EntityFrameworkCore;
using Stefanini.Order.Domain.Interfaces;
using System.Data;

namespace Stefanini.Order.Infra.Context
{
    public class EfCore:  DbContext, IApplicationDbContext
    {

        public DbSet<Domain.Entites.Product> Product { get; set; }
        public DbSet<Domain.Entites.Order> Order { get; set; }
        public DbSet<Domain.Entites.OrderItem> OrderItem { get; set; }
        public IDbConnection Connection => Database.GetDbConnection();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer(Util.WebConfig.GETSTRINCONNECTION);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Mapping.Product());
      
        modelBuilder.ApplyConfiguration(new Mapping.Order());

        modelBuilder.ApplyConfiguration(new Mapping.OrderItem());
      


    }




}
}

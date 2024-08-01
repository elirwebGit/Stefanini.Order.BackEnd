using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stefanini.Order.Infra.Mapping
{
    public class Product : Common.MapBase<Domain.Entites.Product>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entites.Product> builder)
        {
            base.Configure(builder);

            builder.ToTable("Product");
            builder.Property(p => p.Id).HasColumnName("ProductId");
            builder.Property(p => p.Value).HasColumnType("decimal(10,2)");
            builder.Property(p => p.ProductName).HasColumnType("varchar(20)");


        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Stefanini.Order.Infra.Mapping
{
    public class Order : Common.MapBase<Domain.Entites.Order>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entites.Order> builder)
        {
            base.Configure(builder);

            builder.ToTable("Order");
            builder.Property(p => p.Id).HasColumnName("OrderId");
            builder.Property(p => p.CreateAt).ValueGeneratedOnAdd();
            builder.Property(p => p.CustomerName).HasColumnType("varchar(60)");
            builder.Property(p => p.CustomerEmail).HasColumnType("varchar(60)");

        }
    }
}
﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stefanini.Order.Infra.Mapping
{
    public class OrderItem : Common.MapBase<Domain.Entites.OrderItem>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entites.OrderItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("OrderItem");
            builder.Property(p => p.Id).HasColumnName("OrderItemId");

            builder.HasOne(u => u.Product).WithOne(c => c.OrderItems).
            HasForeignKey<Domain.Entites.OrderItem>(b => b.ProductId).
            OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(c => c.ProductId).IsUnique(false);

            builder.HasOne(s => s.Order)
           .WithMany(g => g.OrderItem);
            builder.Property(p => p.OrderId).HasColumnName("OrderId");

            builder.Property(p => p.Value).HasColumnType("decimal(10,2)");




        }
    }
}

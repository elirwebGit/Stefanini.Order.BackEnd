using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Stefanini.Order.Infra.Common
{
    public class MapBase<T> : IEntityTypeConfiguration<T> where T : Domain.Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}



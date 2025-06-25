using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.ToTable("orders");

            builder.HasKey(x => x.Id).HasName("id");

            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

            builder.Ignore(x => x.Total);

            builder.HasMany(x => x.Items)
                .WithOne()
                .HasForeignKey(x => x.OrderId);
        }
    }
}

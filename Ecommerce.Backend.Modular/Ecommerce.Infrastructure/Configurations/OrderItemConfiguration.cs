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
    public class ProductsConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_items");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OrderId).HasColumnName("order_id").IsRequired();

            builder.Property(x => x.ProductId).HasColumnName("product_id").IsRequired();

            builder.Property(x => x.ProductName).HasColumnName("product_name").IsRequired();

            builder.Property(x => x.Quantity).HasColumnName("quantity").IsRequired();

            builder.Property(x => x.UnitPrice).HasColumnName("unit_price").IsRequired();
        }
    }
}

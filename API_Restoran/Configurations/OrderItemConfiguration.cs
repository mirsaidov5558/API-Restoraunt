using API_Restoran.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Restoran.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> b)
        {
            b.ToTable("order_items");

            b.HasKey(oi => oi.Id);
            b.Property(oi => oi.Id).HasColumnName("id");

            b.Property(oi => oi.OrderId).HasColumnName("order_id");
            b.HasOne(oi => oi.Order)
             .WithMany(o => o.OrderItems)
             .HasForeignKey(oi => oi.OrderId)
             .OnDelete(DeleteBehavior.Cascade);

            b.Property(oi => oi.DishId).HasColumnName("dish_id");
            b.HasOne(oi => oi.Dish)
             .WithMany(d => d.OrderItems)
             .HasForeignKey(oi => oi.DishId)
             .OnDelete(DeleteBehavior.Restrict);

            b.Property(oi => oi.Count)
             .HasColumnName("count")
             .IsRequired();

            b.Property(oi => oi.Price)
             .HasColumnName("price")
             .HasColumnType("numeric(10,2)")
             .IsRequired();

            // ✅ Правильное место для check constraints
            b.HasCheckConstraint("CK_order_items_count", "\"count\" > 0");
            b.HasCheckConstraint("CK_order_items_price", "price >= 0");

            b.HasIndex(oi => new { oi.OrderId, oi.DishId }).IsUnique();
        }
    }
}

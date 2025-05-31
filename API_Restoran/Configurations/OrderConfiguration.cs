using API_Restoran.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");

            // PK
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasColumnName("id");

            // Table relation
            builder.Property(o => o.TableId).HasColumnName("table_id");
            builder.HasOne(o => o.Table)
                   .WithMany(t => t.Orders)
                   .HasForeignKey(o => o.TableId)
                   .OnDelete(DeleteBehavior.SetNull);

            // User relation (если у User нет Orders, замени .WithMany() без параметра)
            builder.Property(o => o.UserId).HasColumnName("user_id");
            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders) // <‑‑ проверь, есть ли коллекция Orders в User
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Status relation — ГЛАВНОЕ исправление
            builder.Property(o => o.StatusId).HasColumnName("status_id");
            builder.HasOne(o => o.Status)
                   .WithMany(s => s.Orders) // <‑‑ указали навигацию
                   .HasForeignKey(o => o.StatusId)
                   .OnDelete(DeleteBehavior.SetNull);

            // Other fields
            builder.Property(o => o.TotalSum)
                   .HasColumnName("total_sum")
                   .HasColumnType("decimal(18,2)");

            builder.Property(o => o.CreatedAt).HasColumnName("created_at");

            // OrderItems one‑to‑many
            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.OrderId);

            // MenuKitchen one‑to‑one
            builder.HasOne(o => o.MenuKitchen)
                   .WithOne(mk => mk.Order)
                   .HasForeignKey<MenuKitchen>(mk => mk.OrderId);
        }
    }
}
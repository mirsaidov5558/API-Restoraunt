using API_Restoran.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Configurations
{
    public class MenuKitchenConfiguration : IEntityTypeConfiguration<MenuKitchen>
    {
        public void Configure(EntityTypeBuilder<MenuKitchen> b)
        {
            b.ToTable("menu_kitchen");

            b.HasKey(mk => mk.Id);
            b.Property(mk => mk.Id).HasColumnName("id");

            b.Property(mk => mk.OrderId).HasColumnName("order_id");
            b.HasOne(mk => mk.Order)
              .WithOne(o => o.MenuKitchen)
              .HasForeignKey<MenuKitchen>(mk => mk.OrderId)
              .OnDelete(DeleteBehavior.Cascade);

            b.Property(mk => mk.SentAt)
              .HasColumnName("sent_at")
              .HasDefaultValueSql("NOW()");

            b.HasIndex(mk => mk.OrderId).IsUnique();   // один-к-одному
        }
    }
}
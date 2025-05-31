using API_Restoran.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> b)
        {
            b.ToTable("menu");

            b.HasKey(m => m.Id);
            b.Property(m => m.Id).HasColumnName("id");

            b.Property(m => m.TableId).HasColumnName("table_id");
            b.HasOne(m => m.Table)
             .WithMany(t => t.Menus)
             .HasForeignKey(m => m.TableId)
             .OnDelete(DeleteBehavior.Cascade);

            b.Property(m => m.StatusId).HasColumnName("status_id");
            b.HasOne(m => m.Status)
             .WithMany(s => s.Menus)
             .HasForeignKey(m => m.StatusId)
             .OnDelete(DeleteBehavior.Restrict);

            b.Property(m => m.OpenedAt).HasColumnName("opened_at").HasDefaultValueSql("NOW()");
        }
    }
}
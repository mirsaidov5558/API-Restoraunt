using API_Restoran.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Restoran.Configurations
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.ToTable("tables");          // имя таблицы
            builder.HasKey(t => t.Id);

            // ❗️Явно указываем название колонки id
            builder.Property(t => t.Id)
                   .HasColumnName("id");

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(30)
                   .HasColumnName("name");

            builder.HasMany(t => t.Orders)
                   .WithOne(o => o.Table)
                   .HasForeignKey(o => o.TableId);

            builder.HasMany(t => t.Menus)
                   .WithOne(m => m.Table)
                   .HasForeignKey(m => m.TableId);
        }
    }
}
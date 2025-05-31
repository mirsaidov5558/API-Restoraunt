using API_Restoran.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> b)
        {
            b.ToTable("dish");
            b.HasKey(d => d.Id);

            b.Property(d => d.Id)
             .HasColumnName("id");

            b.Property(d => d.Name)
             .HasColumnName("name")
             .HasMaxLength(150)
             .IsRequired();

            b.HasIndex(d => d.Name).IsUnique();

            b.Property(d => d.Sum)
             .HasColumnName("sum")
             .HasPrecision(10, 2)
             .IsRequired();
        }
    }
}

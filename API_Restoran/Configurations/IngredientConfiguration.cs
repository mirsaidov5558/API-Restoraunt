using API_Restoran.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> b)
        {
            b.ToTable("ingredients");
            b.HasKey(x => x.Id);

            b.Property(x => x.Id)
             .HasColumnName("id");

            b.Property(x => x.Name)
             .HasColumnName("name")
             .HasMaxLength(120)
             .IsRequired();

            b.HasIndex(x => x.Name).IsUnique();
        }
    }
}

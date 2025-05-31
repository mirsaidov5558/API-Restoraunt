using API_Restoran.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Configurations
{
    public class DishIngredientConfiguration : IEntityTypeConfiguration<DishIngredient>
    {
        public void Configure(EntityTypeBuilder<DishIngredient> b)
        {
            b.ToTable("dish_ingredients");

            // ⚑ PK
            b.HasKey(di => di.Id);
            b.Property(di => di.Id).HasColumnName("id");

            // ⚑ FK → dish
            b.Property(di => di.DishId).HasColumnName("dish_id");
            b.HasOne(di => di.Dish)
              .WithMany(d => d.DishIngredients)
              .HasForeignKey(di => di.DishId)
              .OnDelete(DeleteBehavior.Cascade);

            // ⚑ FK → ingredient
            b.Property(di => di.IngredientId).HasColumnName("ingredient_id");
            b.HasOne(di => di.Ingredient)
              .WithMany(i => i.DishIngredients)
              .HasForeignKey(di => di.IngredientId)
              .OnDelete(DeleteBehavior.Restrict);

            // ⚑ уникальная пара (dish_id, ingredient_id)
            b.HasIndex(di => new { di.DishId, di.IngredientId }).IsUnique();
        }
    }
}

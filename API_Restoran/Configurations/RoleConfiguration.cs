using API_Restoran.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Restoran.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role");          // схема уже "cafe" по умолчанию

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                   .HasColumnName("id");      // чтобы точно совпало    

            builder.Property(r => r.Name)
                   .HasColumnName("name")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasIndex(r => r.Name).IsUnique();
        }
    }
}

using API_Restoran.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API_Restoran.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> b)
        {
            b.ToTable("status");
            b.HasKey(s => s.Id);
            b.Property(s => s.Id).HasColumnName("id");
            b.Property(s => s.Name)
             .HasColumnName("name")
             .HasMaxLength(60)
             .IsRequired();
            b.HasIndex(s => s.Name).IsUnique();
        }
    }
}

using API_Restoran.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Restoran.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");    // таблица users

            builder.HasKey(u => u.Id);          // PK

            builder.Property(u => u.Id)
                   .HasColumnName("id");        // <= Явно задаём имена ВСЕМ колонкам

            builder.Property(u => u.Fio)
                   .HasColumnName("fio")        // <— fio
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.Login)
                   .HasColumnName("login")      // <— login
                   .IsRequired()
                   .HasMaxLength(80)
                   .IsUnicode(false);

            builder.Property(u => u.PasswordHash)
                   .HasColumnName("password")   // <— password
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(u => u.RoleId)
                   .HasColumnName("role_id");   // <— role_id

            builder.HasIndex(u => u.Login).IsUnique();

            builder.HasOne(u => u.Role)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.RoleId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        }
    }
}


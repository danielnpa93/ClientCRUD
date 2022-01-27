using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserLogin.Domain.Entities;

namespace UserLogin.Infrastructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("firstName")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("lastName")
                .HasColumnType("VARCHAR(80)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.RegisteredAt)
                .HasColumnName("registeredAt");

            builder.Property(x => x.FullName)
                .HasColumnName("fullName");

        }
    }
}

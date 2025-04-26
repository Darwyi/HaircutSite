using HaircutSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HaircutSite.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> UserBuilder)
        {
            UserBuilder.ToTable("Users").HasKey(i => i.Id);
            UserBuilder.Property(i => i.Id).HasColumnName("Id");
            UserBuilder.Property(n => n.Name).HasColumnName("Name").HasMaxLength(100);
            UserBuilder.Property(p => p.Password).HasColumnName("Password").HasMaxLength(100);
            UserBuilder.Property(ca => ca.CreatedAt).HasColumnName("Created At").HasDefaultValueSql("getdate()");
            UserBuilder.Property(ua => ua.UpdatedAt).HasColumnName("Updated at").HasDefaultValueSql("getdate()");
        }
    }
}

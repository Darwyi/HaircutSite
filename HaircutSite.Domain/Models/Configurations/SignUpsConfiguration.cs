using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HaircutSite.Domain.Models.Configurations
{
    public class SignUpsConfiguration : IEntityTypeConfiguration<SignUps>
    {
        public void Configure(EntityTypeBuilder<SignUps> builder)
        {
            builder.ToTable("SignUps").HasKey(i => i.Id);
            builder.Property(i => i.Id).HasColumnName("Id");
            builder.Property(u => u.User).HasConversion(v => v.Name, v => new User { Name = v }).HasColumnName("UserName");
            builder.Property(h => h.haircutStyle).HasConversion(v => v.Id, v => new HaircutStyles { Id = v }).HasColumnName("Haircut StyleId").HasMaxLength(100);
            builder.Property(d => d.Date).HasColumnName("Date");
        }
    }
}

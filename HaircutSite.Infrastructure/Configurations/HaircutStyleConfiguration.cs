using HaircutSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HaircutSite.Infrastructure.Configurations
{
    public class HaircutStyleConfiguration : IEntityTypeConfiguration<HaircutStyles>
    {
        public void Configure(EntityTypeBuilder<HaircutStyles> builder)
        {
            builder.ToTable("Hair Styles").HasKey(i => i.Id);
            builder.Property(i => i.Id).HasColumnName("Id");
            builder.Property(n => n.Name).HasColumnName("Name").HasMaxLength(100);
            builder.Property(d => d.Description).HasColumnName("Description").HasMaxLength(100);
            builder.Property(p => p.Price).HasColumnName("Price").HasMaxLength(100);
            builder.Property(d => d.Duration).HasColumnName("Duration").HasConversion(
                v => v.ToString(@"hh\:mm"),
                v => TimeSpan.Parse(v));
        }
    }
}

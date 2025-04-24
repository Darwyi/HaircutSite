using HaircutSite.Domain.Entities;
using HaircutSite.WebUI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HaircutSite.WebUI.Context.Configurations
{
    public class HaircutStyleConfiguration : IEntityTypeConfiguration<HaircutStyles>
    {
        public void Configure(EntityTypeBuilder<HaircutStyles> builder)
        {
            builder.ToTable("Hair Styles").HasKey(i => i.Id);
            builder.Property(i => i.Id).HasColumnName("Id");
            builder.Property(n => n.Name).HasColumnName("Name").HasMaxLength(100);
            builder.Property(d => d.Description).HasColumnName("Description").HasMaxLength(100);

            builder.HasData(HaircutStyle.All.Select(h => new HaircutStyles
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description
            }));
        }
    }
}

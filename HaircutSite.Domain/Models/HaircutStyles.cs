using Nest;

namespace HaircutSite.Domain.Models
{
    public class HaircutStyles
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Price { get; set; } = null!;
        public TimeSpan Duration { get; set; }
        public HaircutStyles()
        {
        }
    }
}

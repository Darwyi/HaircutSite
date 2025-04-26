using HaircutSite.Domain.Models;
using Nest;

namespace WebUI.ViewModel
{
    public class HaircutStylesViewModel
    {
        public string name { get; set; } = string.Empty; // Fix for CS8618
        public string description { get; set; } = string.Empty; // Fix for CS8618
        public string price { get; set; } = null!;
        public TimeSpan Duration { get; set; }

        public HaircutStylesViewModel() { }

        public HaircutStyles ToStyle()
        {
            var newStyle = new HaircutStyles
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = price,
                Duration = Duration
            };

            return newStyle;
        }
    }
}

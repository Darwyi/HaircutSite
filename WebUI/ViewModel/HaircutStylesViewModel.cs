using HaircutSite.Domain.Models;
using Nest;
using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModel
{
    public class HaircutStylesViewModel
    {
        public string name { get; set; } = string.Empty;
        public string? description { get; set; } = string.Empty;
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
                    Duration = TimeSpan.Parse(Duration.ToString())
                };

            return newStyle;
        }
    }
}

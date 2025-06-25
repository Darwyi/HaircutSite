using Humanizer;

namespace HaircutSite.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //public  tgID { get; set; } = null!;
        public User()
        {
        }
        public static User Create(string name, string password)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Password = password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }
    }
}

using HaircutSite.Domain.Models;

namespace WebUI.ViewModel
{
    public class UserViewModel 
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public UserViewModel(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public User ToUser()
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Password = Password,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return newUser;
        }
    }
}

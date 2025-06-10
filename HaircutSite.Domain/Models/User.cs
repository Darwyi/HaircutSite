namespace HaircutSite.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //public  tgID { get; set; } = null!;
        public User()
        {
        }

        //public User(Guid id, string name, string password, DateTime date)
        //{
        //    Id = id;
        //    Name = name;
        //    Password = password;
        //}
    }
}

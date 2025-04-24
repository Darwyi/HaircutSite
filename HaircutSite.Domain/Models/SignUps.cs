namespace HaircutSite.Domain.Models
{
    public class SignUps
    {
        public long Id { get; set; }
        public User User { get; set; } = null!;
        public HaircutStyles haircutStyle { get; set; } = null!;
        public DateTime Date { get; set; }

        public SignUps()
        {
        }
    }
}

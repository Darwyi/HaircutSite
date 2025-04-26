using HaircutSite.Domain.Models;

namespace WebUI.ViewModel
{
    public class AppointmentViewModel
    {
        public Guid HaircutStyleId { get; set; }
        public Guid userId { get; set; }
        public DateTime Date { get; set; }
        public Appointment ToAppointment()
        {
            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                haircutStyleId = HaircutStyleId,
                UserId = userId,
                Date = Date,
            };
            return appointment;
        }
    }
}

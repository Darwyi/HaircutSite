﻿namespace HaircutSite.Domain.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid haircutStyleId { get; set; }
        public DateTime Date { get; set; }
        public string? Additional { get; set; }

        public Appointment()
        {
        }
    }
}

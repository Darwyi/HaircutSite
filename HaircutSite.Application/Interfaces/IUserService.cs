﻿using HaircutSite.Domain.Models;

namespace HaircutSite.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(Guid id);
        Task UpdateUser(Guid id, User user);
        Task RegisterUser(User user);
        Task<List<Appointment>?> GetUserAppointments(Guid id);

    }
}

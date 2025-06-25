using HaircutSite.Domain.Models;
using HaircutSite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HaircutSite.Infrastructure.Repositories
{
    public class UserRepository : HaircutSite.Domain.Interfaces.IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task RegisterUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(Guid id, User user)
        {
            user.Id = id;
            _dbContext.Users.Remove(GetUserById(id).Result);
            await _dbContext.SaveChangesAsync();

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
       
        public async Task<List<Appointment>> GetUserAppointments(Guid id)
        {
            var appointments = await _dbContext.Appointments
                .Where(a => a.UserId == id)
                .ToListAsync();

            return appointments;
        }

        public async Task<User> GetUserByName(String username)
        {
            var trackedUser = await _dbContext.Users
                .Where(u => u.Name == username)
                .FirstOrDefaultAsync();

            return trackedUser;
        }
    }
}

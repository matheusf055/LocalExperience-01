using LocalExperience.Domain.Users;
using LocalExperience.Domain.Users.Repositories;
using LocalExperience.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LocalExperience.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly LocalExperienceDbContext _context;

        public UserRepository(LocalExperienceDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByIdWithDetails(Guid id)
        {
            return await _context.Users
                 .Include(u => u.Trips)
                 .FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<User> GetByEmail(string email)
        {
           return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

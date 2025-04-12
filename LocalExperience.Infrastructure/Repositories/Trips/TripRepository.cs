using LocalExperience.Domain.Trips;
using LocalExperience.Domain.Trips.Repositories;
using LocalExperience.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LocalExperience.Infrastructure.Repositories.Trips
{
    public class TripRepository : ITripRepository
    {
        private readonly LocalExperienceDbContext _context;

        public TripRepository(LocalExperienceDbContext context)
        {
            _context = context;
        }

        public async Task<Trip> GetByIdAsync(Guid id)
        {
            return await _context.Trips.FindAsync(id);
        }

        public async Task<Trip> GetByIdWithDetailsAsync(Guid id)
        {
            return await _context.Trips
               .Include(t => t.User)
               .Include(t => t.TripsInterestProfile)
               .Include(t => t.Itineraries)
               .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Trip>> GetUserTripsAsync(Guid userId)
        {
            return await _context.Trips
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreateDate)
                .ToListAsync();
        }

        public async Task<Trip> GetByShareCodeAsync(string shareCode)
        {
            return await _context.Trips.FirstOrDefaultAsync(t => t.ShareCode == shareCode);
        }

        public async Task AddAsync(Trip trip)
        {
            await _context.Trips.AddAsync(trip);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Trip trip)
        {
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Trips.FindAsync(id);
            if (user != null)
            {
                _context.Trips.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using LocalExperience.Domain.Trips;
using LocalExperience.Domain.Trips.Repositories;
using LocalExperience.Infrastructure.Persistence;

namespace LocalExperience.Infrastructure.Repositories.TripsInterestProfiles
{
    public class TripsInterestProfileRepository : ITripsInterestProfileRepository
    {
        private readonly LocalExperienceDbContext _context;

        public TripsInterestProfileRepository(LocalExperienceDbContext context)
        {
            _context = context;
        }

        public async Task<TripsInterestProfile> GetByTripIdAsync(Guid tripId)
        {
            return await _context.TripsInterestProfile.FindAsync(tripId);
        }

        public async Task AddAsync(TripsInterestProfile profile)
        {
            await _context.TripsInterestProfile.AddAsync(profile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TripsInterestProfile profile)
        {
            _context.TripsInterestProfile.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tripInterestProfile = _context.TripsInterestProfile.Find(id);
            if (tripInterestProfile != null)
            {
                _context.TripsInterestProfile.Remove(tripInterestProfile);
                await _context.SaveChangesAsync();
            }
        }
    }
}

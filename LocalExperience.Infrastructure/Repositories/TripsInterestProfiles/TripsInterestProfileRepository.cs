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

        public async Task<TripsInterestProfile> GetByTripId(Guid tripId)
        {
            return await _context.TripsInterestProfile.FindAsync(tripId);
        }

        public async Task Create(TripsInterestProfile profile)
        {
            await _context.TripsInterestProfile.AddAsync(profile);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TripsInterestProfile profile)
        {
            _context.TripsInterestProfile.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
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

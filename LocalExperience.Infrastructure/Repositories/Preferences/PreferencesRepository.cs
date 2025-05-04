using LocalExperience.Domain.Preferences;
using LocalExperience.Domain.Preferences.Repositories;
using LocalExperience.Infrastructure.Persistence;

namespace LocalExperience.Infrastructure.Repositories.Preferences
{
    public class PreferencesRepository : IPreferencesRepository
    {
        private readonly LocalExperienceDbContext _context;

        public PreferencesRepository(LocalExperienceDbContext context)
        {
            _context = context;
        }

        public async Task<Preference> GetByTripId(Guid tripId)
        {
            return await _context.preference.FindAsync(tripId);
        }

        public async Task Create(Preference profile)
        {
            await _context.preference.AddAsync(profile);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Preference profile)
        {
            _context.preference.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var preferences = _context.preference.Find(id);
            if (preferences != null)
            {
                _context.preference.Remove(preferences);
                await _context.SaveChangesAsync();
            }
        }
    }
}

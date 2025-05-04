using LocalExperience.Domain.Preferences;
using LocalExperience.Domain.Preferences.Repositories;
using LocalExperience.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            return await _context.Preference.FirstOrDefaultAsync(p => p.TripId == tripId);
        }

        public async Task Create(Preference profile)
        {
            await _context.Preference.AddAsync(profile);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Preference profile)
        {
            _context.Preference.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var preferences = _context.Preference.Find(id);
            if (preferences != null)
            {
                _context.Preference.Remove(preferences);
                await _context.SaveChangesAsync();
            }
        }
    }
}

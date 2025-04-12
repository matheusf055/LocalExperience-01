using LocalExperience.Domain.Itineraries;
using LocalExperience.Domain.Itineraries.Repositories;
using LocalExperience.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LocalExperience.Infrastructure.Repositories.Itineraries
{
    public class ItineraryRepository : IItineraryRepository
    {
        private readonly LocalExperienceDbContext _context;

        public ItineraryRepository(LocalExperienceDbContext context)
        {
            _context = context;
        }

        public async Task<Itinerary> GetByIdAsync(Guid id)
        {
            return await _context.Itineraries.FindAsync(id);
        }

        public async Task<Itinerary> GetByIdWithDetailsAsync(Guid id)
        {
            return await _context.Itineraries
                .Include(i => i.Trip)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Itinerary> GetLatestForTripAsync(Guid tripId)
        {
            return await _context.Itineraries
                .Where(i => i.TripId == tripId)
                .OrderByDescending(i => i.CreateDate)
                .FirstOrDefaultAsync();
        }

        public async Task<Itinerary> GetLatestForTripWithDetailsAsync(Guid tripId)
        {
            return await _context.Itineraries
                .Where(i => i.TripId == tripId)
                .OrderByDescending(i => i.CreateDate)
                .FirstOrDefaultAsync();
        }


        public async Task AddAsync(Itinerary itinerary)
        {
            await _context.Itineraries.AddAsync(itinerary);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Itinerary itinerary)
        {
            _context.Itineraries.Update(itinerary);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var itinerary = await _context.Itineraries.FindAsync(id);
            if (itinerary != null)
            {
                _context.Itineraries.Remove(itinerary);
                await _context.SaveChangesAsync();
            }
        }
    }
}

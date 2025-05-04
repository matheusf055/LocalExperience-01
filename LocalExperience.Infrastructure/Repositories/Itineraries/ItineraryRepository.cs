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

        public async Task<Itinerary> GetById(Guid id)
        {
            return await _context.Itineraries.FindAsync(id);
        }

        public async Task Create(Itinerary itinerary)
        {
            await _context.Itineraries.AddAsync(itinerary);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
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

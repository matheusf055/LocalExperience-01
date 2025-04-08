using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Domain.Itineraries.Repositories
{
    public interface IItineraryRepository
    {
        Task<Itinerary> GetByIdAsync(Guid id);
        Task<Itinerary> GetByIdWithDetailsAsync(Guid id);
        Task<Itinerary> GetLatestForTripAsync(Guid tripId);
        Task<Itinerary> GetLatestForTripWithDetailsAsync(Guid tripId);
        Task AddAsync(Itinerary itinerary);
        Task UpdateAsync(Itinerary itinerary);
        Task DeleteAsync(Guid id);
    }
}

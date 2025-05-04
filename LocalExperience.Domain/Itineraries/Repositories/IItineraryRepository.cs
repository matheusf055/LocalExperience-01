using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Domain.Itineraries.Repositories
{
    public interface IItineraryRepository
    {
        Task<Itinerary> GetById(Guid id);
        Task Create(Itinerary itinerary);
        Task Update(Itinerary itinerary);
        Task Delete(Guid id);
    }
}

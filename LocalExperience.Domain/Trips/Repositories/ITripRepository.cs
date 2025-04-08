using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Domain.Trips.Repositories
{
    public interface ITripRepository
    {
        Task<Trip> GetByIdAsync(Guid id);
        Task<Trip> GetByIdWithDetailsAsync(Guid id);
        Task<Trip> GetByShareCodeAsync(string shareCode);
        Task<List<Trip>> GetUserTripsAsync(Guid userId);
        Task AddAsync(Trip trip);
        Task UpdateAsync(Trip trip);
        Task DeleteAsync(Guid id);
    }
}

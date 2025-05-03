using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Domain.Trips.Repositories
{
    public interface ITripRepository
    {
        Task<Trip> GetById(Guid id);
        Task<Trip> GetByIdWithDetails(Guid id);
        Task<Trip> GetByShareCode(string shareCode);
        Task<List<Trip>> GetAll(Guid userId);
        Task Create(Trip trip);
        Task Update(Trip trip);
        Task Delete(Guid id);
    }
}

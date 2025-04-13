using LocalExperience.AppServices.Interfaces.Trips.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Interfaces.Trips
{
    public interface ITripAppService
    {
        Task<TripDto> GetByIdAsync(Guid id);
        Task<TripDto> GetByIdWithDetailsAsync(Guid id);
        Task<TripDto> GetByShareCodeAsync(string shareCode);
        Task<List<TripDto>> GetUserTripsAsync(Guid userId);
        Task AddAsync(CreateTripDto tripDto);
        Task UpdateAsync(UpdateTripDto tripDto);
        Task DeleteAsync(Guid id);
    }
}

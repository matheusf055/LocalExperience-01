using LocalExperience.AppServices.Interfaces.Trips.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Interfaces.Trips
{
    public interface ITripAppService
    {
        Task<TripDto> GetById(Guid id);
        Task<TripDto> GetByIdWithDetails(Guid id);
        Task<TripDto> GetByShareCode(string shareCode);
        Task<List<TripDto>> GetAll(Guid userId);
        Task Create(CreateTripDto tripDto);
        Task Update(UpdateTripDto tripDto);
        Task Delete(Guid id);
    }
}

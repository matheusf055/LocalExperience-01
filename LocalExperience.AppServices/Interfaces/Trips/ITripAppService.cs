using LocalExperience.AppServices.Trips.Commands;
using LocalExperience.AppServices.Trips.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Interfaces.Trips
{
    public interface ITripAppService
    {
        Task<TripDto> GetById(Guid id);
        Task<TripDto> GetByShareCode(string shareCode);
        Task<List<TripDto>> GetAll(Guid userId);
        Task<TripDto> Create(CreateTripCommand command);
        Task Update(UpdateTripCommand command);
        Task Delete(Guid id);
    }
}

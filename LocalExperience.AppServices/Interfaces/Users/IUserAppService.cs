using LocalExperience.AppServices.Interfaces.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Interfaces.Users
{
    public interface IUserAppService
    {
        Task<UserDto> GetByIdAsync(Guid id);
        Task<UserWithTripsDto> GetByIdWithDetailsAsync(Guid id);
        Task<UserDto> LoginAsync(UserLoginDto loginDto);
        Task AddAsync(UserRegisterDto user);
        Task UpdateAsync(UserUpdateDto user);
        Task DeleteAsync(Guid id);
    }
}

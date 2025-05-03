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
        Task<UserDto> GetById(Guid id);
        Task<UserWithTripsDto> GetByIdWithDetails(Guid id);
        Task<UserDto> Login(UserLoginDto loginDto);
        Task Create(UserRegisterDto user);
        Task Update(UserUpdateDto user);
        Task Delete(Guid id);
    }
}

using LocalExperience.AppServices.Users.Commands;
using LocalExperience.AppServices.Users.DTOs;
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
        Task Update(UpdateUserCommand command);
        Task Delete(Guid id);
    }
}

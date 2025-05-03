using LocalExperience.AppServices.Users.DTOs;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Interfaces.Auth
{
    public interface IAuthAppService
    {
        Task Register(UserRegisterDto userDto);
        Task<UserDto> Login(UserLoginDto loginDto);
    }
}

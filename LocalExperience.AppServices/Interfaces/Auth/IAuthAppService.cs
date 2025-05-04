using LocalExperience.AppServices.Auth.Commands;
using LocalExperience.AppServices.Auth.DTOs;
using LocalExperience.AppServices.Users.DTOs;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Interfaces.Auth
{
    public interface IAuthAppService
    {
        Task Register(RegisterUserCommand command);
        Task<AuthDto> Login(LoginUserCommand command);
    }
}

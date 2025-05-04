using LocalExperience.AppServices.Interfaces.Users;
using LocalExperience.AppServices.Users.Commands;
using LocalExperience.AppServices.Users.DTOs;
using LocalExperience.Domain.Users;
using LocalExperience.Domain.Users.Repositories;
using LocalExperience.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Users
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null) throw new KeyNotFoundException("Usuário não foi encontrado.");

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                CreateDate = user.CreateDate
            };
        }

        public async Task Update(UpdateUserCommand command)
        {
            var user = await _userRepository.GetByEmail(command.Email);
            if (user == null) throw new KeyNotFoundException("Usuário não encontrado.");

            var isCurrentPasswordValid = PasswordHasher.VerifyPassword(user.PasswordHash, command.CurrentPassword);
            if (isCurrentPasswordValid == false) throw new UnauthorizedAccessException("Senha atual inválida.");

            if (command.NewPassword != command.ConfirmNewPassword) throw new ArgumentException("A nova senha e a confirmação da nova senha não coincidem.");

            var newHashedPassword = PasswordHasher.HashPassword(command.NewPassword);
            user.SetPasswordHash(newHashedPassword);

            user.Name = command.Name;

            await _userRepository.Update(user);
        }

        public async Task Delete(Guid id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null) throw new KeyNotFoundException("Usuário não encontrado.");

            await _userRepository.Delete(id);
        }
    }
}

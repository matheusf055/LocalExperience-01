using LocalExperience.AppServices.Interfaces.Users;
using LocalExperience.AppServices.Interfaces.Users.DTOs;
using LocalExperience.AppServices.Mappers.Users;
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

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
           var user = await _userRepository.GetByIdAsync(id);
           if (user == null) throw new KeyNotFoundException("Usuário não foi encontrado.");

           return new UserDto
           {
               Id = user.Id,
               Email = user.Email,
               Name = user.Name,
               CreateDate = user.CreateDate
           };
        }

        public async Task<UserWithTripsDto> GetByIdWithDetailsAsync(Guid id)
        {
            var user = await _userRepository.GetByIdWithDetailsAsync(id);
            if (user == null) throw new KeyNotFoundException("Usuário não foi encontrado.");

            return UserMapper.ConvertUserWithTripsDto(user);
        }

        public async Task AddAsync(UserRegisterDto userDto)
        {
            var isUserExists = await _userRepository.GetByEmailAsync(userDto.Email);
            if (isUserExists != null) throw new ArgumentException("Usuário já existe com esse e-mail.");

            var hashedPassword = PasswordHasher.HashPassword(userDto.Password);
            var user = new User(userDto.Email, userDto.Name);
            user.SetPasswordHash(hashedPassword);

            await _userRepository.AddAsync(user);
        }

        public async Task<UserDto> LoginAsync(UserLoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null) throw new KeyNotFoundException("Usuário não encontrado.");

            var isPasswordValid = PasswordHasher.VerifyPassword(user.PasswordHash, loginDto.Password);
            if (isPasswordValid == false) throw new UnauthorizedAccessException("Senha inválida.");

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                CreateDate = user.CreateDate
            };
        }

        public async Task UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var user = await _userRepository.GetByEmailAsync(userUpdateDto.Email);
            if (user == null) throw new KeyNotFoundException("Usuário não encontrado.");

            if (string.IsNullOrEmpty(userUpdateDto.CurrentPassword) == false)
            {
                var isCurrentPasswordValid = PasswordHasher.VerifyPassword(user.PasswordHash, userUpdateDto.CurrentPassword);
                if (!isCurrentPasswordValid) throw new UnauthorizedAccessException("Senha atual inválida.");
            }

            if (string.IsNullOrEmpty(userUpdateDto.NewPassword) == false)
            {
                if (userUpdateDto.NewPassword != userUpdateDto.ConfirmNewPassword) throw new ArgumentException("A nova senha e a confirmação da nova senha não coincidem.");

                var newHashedPassword = PasswordHasher.HashPassword(userUpdateDto.NewPassword);
                user.SetPasswordHash(newHashedPassword); 
            }

            if (string.IsNullOrEmpty(userUpdateDto.Name) == false)
            {
                user.Name = userUpdateDto.Name;
            }

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new KeyNotFoundException("Usuário não encontrado.");

            await _userRepository.DeleteAsync(id);
        }
    }
}
